using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface IStudySubjectRepository : IRepository
    {
        Task<StudySubject> Get(string name);
        Task<StudySubject> Get(Guid id);
        Task<IEnumerable<StudySubject>> GetAll();
        Task Add(StudySubject studySubject);
        Task Update(StudySubject studySubject);
        Task Remove(Guid id);
    }
}
