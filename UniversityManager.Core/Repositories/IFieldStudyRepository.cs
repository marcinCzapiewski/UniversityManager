using System;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface IFieldStudyRepository
    {
        Task<FieldStudy> Get(Guid fieldStudyId);
    }
}
