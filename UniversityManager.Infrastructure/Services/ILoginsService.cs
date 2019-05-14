using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.DTOs;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Api.Controllers
{
    public interface ILoginsService : IService
    {
        Task<IEnumerable<LoginDto>> Browse();
    }
}