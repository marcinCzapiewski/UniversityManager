﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Account;
using UniversityManager.Infrastructure.DTOs;
using UniversityManager.Infrastructure.Extentions;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Api.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IMemoryCache _cache;
        private readonly ILoginsService _loginsService;

        public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache cache, ILoginsService loginsService)
            : base(commandDispatcher)
        {
            _cache = cache;
            _loginsService = loginsService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await Dispatch(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }

        [Authorize(Policy = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logins = await _loginsService.Browse();

            return Json(logins);
        }
    }
}