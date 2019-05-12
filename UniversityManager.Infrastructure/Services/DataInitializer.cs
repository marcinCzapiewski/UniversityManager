using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManager.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DataInitializer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Seed()
        {
            var users = await _userService.Browse();
            if (users.Any())
            {
                Logger.Trace("Data was already initialized.");

                return;
            }

            Logger.Trace("Initializing data...");

            for (int i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                await _userService.Register(userId, $"user{i}@test.com",
                                                 username, "secret", "user");

                Logger.Trace($"Adding user: '{username}'.");
            }

            for (var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                Logger.Trace($"Adding admin: '{username}'.");
                await _userService.Register(userId, $"admin{i}@test.com",
                    username, "secret", "admin");
            }
            Logger.Trace("Data was initialized.");
        }
    }
}
