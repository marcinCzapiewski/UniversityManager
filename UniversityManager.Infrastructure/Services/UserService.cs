using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.DTOs;
using UniversityManager.Infrastructure.Exceptions;

namespace UniversityManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper, ILoginRepository loginRepository)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
            _loginRepository = loginRepository;
        }

        public async Task<UserDto> Get(string email)
        {
            var user = await _userRepository.Get(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> Browse()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task Login(string email, string password)
        {
            var user = await _userRepository.Get(email);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials,
                    "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                await _loginRepository.Add(new Login(user));
                return;
            }
            throw new ServiceException(ErrorCodes.InvalidCredentials,
                "Invalid credentials");

        }

        public async Task Register(Guid userId, string email,
            string username, string password, string role)
        {
            var user = await _userRepository.Get(email);
            if (user != null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,
                    $"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            switch (role)
            {
                case "student":
                    user = new Student(userId, email, username, role, hash, salt);
                    break;
                case "lecturer":
                    user = new Lecturer(userId, email, username, role, hash, salt);
                    break;
                default:
                    user = new User(userId, email, username, role, hash, salt);
                    break;
            }

            await _userRepository.Add(user);
        }

        public async Task Update(UserDto user)
        {
            var userToUpdate = await GetUser(user.Id);

            await _userRepository.Update(userToUpdate);
        }

        public async Task ChangePassword(UserDto user, string newPassword)
        {
            var userToUpdate = await GetUser(user.Id);
            if (userToUpdate == null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,
                    $"User with email: '{user.Email}' does not exist.");
            }

            var salt = _encrypter.GetSalt(newPassword);
            var hash = _encrypter.GetHash(newPassword, salt);

            userToUpdate = new User(userToUpdate.Id, userToUpdate.Email, userToUpdate.Username, userToUpdate.Role, hash, salt);

            await _userRepository.Update(userToUpdate);
        }

        private async Task<User> GetUser(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,
                    $"User with email: '{user.Email}' does not exist.");
            }

            return user;
        }
    }
}
