using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Services
{
    public interface IStudySubjectService : IService
    {
        Task<StudySubjectDto> Get(string name);
        Task<StudySubjectDto> Get(Guid id);
        Task Add(string name, Guid fieldStudyId, int semester);
        Task<IEnumerable<StudySubjectDto>> Browse();
    }
}
