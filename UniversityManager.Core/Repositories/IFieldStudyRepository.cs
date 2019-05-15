using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface IFieldStudyRepository
    {
        Task<FieldStudy> Get(string name);
        Task<FieldStudy> Get(Guid id);
        Task<IEnumerable<FieldStudy>> GetAll();
        Task Add(FieldStudy fieldStudy);
        Task Update(FieldStudy fieldStudy);
        Task Remove(Guid id);
    }
}
