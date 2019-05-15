using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;

namespace UniversityManager.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Task<Attendance> Get(Guid id);
        Task<IEnumerable<Attendance>> GetLectureAttendances(Guid LectureId);
        Task<IEnumerable<Attendance>> GetAll();
        Task<IEnumerable<Attendance>> GetStudentAttendances(Guid StudentId);
        Task Add(Attendance studySubject);
        Task Remove(Guid id);
    }
}
