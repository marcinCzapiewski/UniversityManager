using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Attendances;
using UniversityManager.Infrastructure.Services.Interfaces;

namespace UniversityManager.Infrastructure.Handlers.Attendances
{
    public class CreateAttendanceHandler : ICommandHandler<CreateAttendance>
    {
        private readonly IAttendanceService _attendanceService;

        public CreateAttendanceHandler(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public async Task Handle(CreateAttendance command)
        {
            await _attendanceService.Add(command.StudentId, command.LectureId, command.Present);
        }
    }
}
