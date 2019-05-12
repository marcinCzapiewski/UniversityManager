using System;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Users;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Handle(CreateUser command)
        {
            await _userService.Register(Guid.NewGuid(), command.Email, command.Username,
                command.Password, command.Role);
        }
    }
}
