using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.EF;

namespace UniversityManager.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository, ISqlRepository
    {
        private readonly UniversityManagerContext _context;

        public LoginRepository(UniversityManagerContext context)
        {
            _context = context;
        }

        public async Task Add(Login login)
        {
            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();
        }

        public async Task<Login> Get(Guid id)
            => await _context.Logins.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Login> Get(User user)
            => await _context.Logins.SingleOrDefaultAsync(x => x.User.Id == user.Id);

        public async Task<IEnumerable<Login>> GetAll()
            => await _context.Logins.Include(x => x.User).ToListAsync();
    }
}
