using System;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface ILectureRepository
    {
        Task<Lecture> Get(Guid lectureId);
    }
}
