using System;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface IFacultyRepository
    {
        Task<Faculty> Get(Guid facultyId);
    }
}
