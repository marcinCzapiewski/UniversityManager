using System;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Users;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IUserService _userService;

        public ChangeUserPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(ChangeUserPassword command)
        {
            var userDto = await _userService.Get(command.Email);
            await _userService.ChangePassword(userDto, command.NewPassword);
        }
    }
}
