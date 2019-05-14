using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Services
{
    public class LoginsService : ILoginsService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginsService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoginDto>> Browse()
        {
            var logins = await _loginRepository.GetAll();

            return _mapper.Map<IEnumerable<Login>, IEnumerable<LoginDto>>(logins);
        }
    }
}
