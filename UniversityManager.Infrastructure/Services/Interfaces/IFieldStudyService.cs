using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Services.Interfaces
{
    public interface IFieldStudyService : IService
    {
        Task<FieldStudyDto> Get(string name);
        Task<FieldStudyDto> Get(Guid id);
        Task Add(string name, Guid facultyId);
        Task<IEnumerable<FieldStudyDto>> Browse();
    }
}
