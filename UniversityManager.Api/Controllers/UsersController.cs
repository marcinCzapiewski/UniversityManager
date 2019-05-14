using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Users;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.Browse();

            return Json(users);
        }

        [HttpGet("{email}")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.Get(email);

            if (user == null)
                return NotFound();

            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await Dispatch(command);

            return Created($"users/{command.Email}", null);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateUser command)
        {
            await Dispatch(command);

            return Accepted($"users/{command.NewEmail}", null);
        }

        [Authorize]
        [HttpPut("{password}")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangeUserPassword command)
        {
            await Dispatch(command);

            return NoContent();
        }
    }
}
