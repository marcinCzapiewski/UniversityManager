using System;
using System.Collections.Generic;
using System.Text;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
