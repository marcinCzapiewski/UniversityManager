using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Account;
using UniversityManager.Infrastructure.Extentions;

namespace UniversityManager.Api.Controllers
{
    public class LoginController : BaseController
    {
        private IMemoryCache _cache;

        public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache cache)
            : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await Dispatch(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}