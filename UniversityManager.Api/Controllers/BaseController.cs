using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManager.Infrastructure.Commands;

namespace UniversityManager.Api.Controllers
{
    [Route("[controller]")]
    public class BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public BaseController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task Dispatch<T>(T command) where T : ICommand
            => await _commandDispatcher.Dispatch(command);
    }
}
