using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<AttendanceDto> Get(Guid id);
        Task Add(Guid studentId, Guid lectureId, bool present);
        Task<IEnumerable<AttendanceDto>> Browse();
        Task Remove(Guid id);
        Task<IEnumerable<AttendanceDto>> GetStudentAttendences(Guid studentId);
    }
}
