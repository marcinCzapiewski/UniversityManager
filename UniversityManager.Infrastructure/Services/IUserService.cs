using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> Get(string email);
        Task<IEnumerable<UserDto>> Browse();
        Task Register(Guid userId, string email,
            string username, string password, string role);
        Task Login(string email, string password);
    }
}
