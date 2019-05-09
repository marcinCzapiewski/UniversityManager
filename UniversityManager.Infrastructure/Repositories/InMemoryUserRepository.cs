using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;

namespace UniversityManager.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>();

        public async Task<User> Get(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> Get(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAll()
            => await Task.FromResult(_users);

        public async Task Add(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task Remove(Guid id)
        {
            var user = await Get(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task Update(User user)
        {
            await Task.CompletedTask;
        }
    }
}
