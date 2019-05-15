using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.Exceptions;
using UniversityManager.Infrastructure.Services;
using Xunit;

namespace UniversityManager.Tests.Infrastructure.ServicesTests
{
    public class UserServiceTests
    {
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IEncrypter> _encrypterMock = new Mock<IEncrypter>();
        private readonly Mock<ILoginRepository> _loginRepositoryMock = new Mock<ILoginRepository>();


        [Fact]
        public async Task register_should_invoke_add_on_repository()
        {
            _encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            _encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");

            var userService = new UserService(_userRepositoryMock.Object, _encrypterMock.Object, _mapperMock.Object, _loginRepositoryMock.Object);

            await userService.Register(Guid.NewGuid(), "user@gmail.com", "user1", "secret", "user");

            _userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task calling_get_and_user_exists_it_should_invoke_user_repository_get()
        {
            _encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            _encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");

            var userService = new UserService(_userRepositoryMock.Object, _encrypterMock.Object, _mapperMock.Object, _loginRepositoryMock.Object);
            await userService.Get("user1@email.com");

            var user = new User(Guid.NewGuid(), "user1@email.com", "user1", "user", "secret", "salt");

            _userRepositoryMock.Setup(x => x.Get(It.IsAny<string>()))
                              .ReturnsAsync(user);

            _userRepositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task calling_get_and_user_does_not_exist_it_should_invoke_user_repository_get()
        {
            var userService = new UserService(_userRepositoryMock.Object, _encrypterMock.Object, _mapperMock.Object, _loginRepositoryMock.Object);
            await userService.Get("user@email.com");

            _userRepositoryMock.Setup(x => x.Get("user@email.com"))
                              .ReturnsAsync(() => null);

            _userRepositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task browse_should_invoke_user_repository_getAll_and_result_not_null()
        {
            var userService = new UserService(_userRepositoryMock.Object, _encrypterMock.Object, _mapperMock.Object, _loginRepositoryMock.Object);
            var result = await userService.Browse();

            _userRepositoryMock.Setup(x => x.GetAll());

            Assert.NotNull(result);
            _userRepositoryMock.Verify(x => x.GetAll(), Times.Once());
        }

        [Fact]
        public async Task given_invalid_credentials_login_throws_ServiceException()
        {
            var userService = new UserService(_userRepositoryMock.Object, _encrypterMock.Object, _mapperMock.Object, _loginRepositoryMock.Object);

            var email = "user1@email.com";
            var password = "pass";

            await Assert.ThrowsAsync<ServiceException>(() => userService.Login(email, null));
            await Assert.ThrowsAsync<ServiceException>(() => userService.Login(null, password));
            await Assert.ThrowsAsync<ServiceException>(() => userService.Login(email, password));
        }
    }
}
