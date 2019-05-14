using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Users;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Infrastructure.Handlers.Users
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Handle(UpdateUser command)
        {
            var userDto = await _userService.Get(command.OldEmail);
            await _userService.Update(userDto);
        }
    }
}
