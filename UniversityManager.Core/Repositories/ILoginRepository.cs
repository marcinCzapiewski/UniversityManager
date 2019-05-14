using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface ILoginRepository : IRepository
    {
        Task<Login> Get(Guid id);
        Task<Login> Get(User user);
        Task<IEnumerable<Login>> GetAll();
        Task Add(Login login);
    }
}
