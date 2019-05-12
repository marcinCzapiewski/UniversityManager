using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Account;
using UniversityManager.Infrastructure.Extentions;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Infrastructure.Handlers.Account
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IHandler handler, IUserService userService,
                            IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _handler = handler;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task Handle(Login command)
            => await _handler
                .Run(async () => await _userService.Login(command.Email, command.Password))
                .Next()
                .Run(async () =>
                {
                    var user = await _userService.Get(command.Email);
                    var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
                    _cache.SetJwt(command.TokenId, jwt);
                })
                .Next()
                .ExecuteAllAsync();
    }
}
