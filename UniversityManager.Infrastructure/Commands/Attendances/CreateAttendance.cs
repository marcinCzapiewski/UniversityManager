using System;

namespace UniversityManager.Infrastructure.Commands.Attendances
{
    public class CreateAttendance : ICommand
    {
        public Guid LectureId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public bool Present { get; protected set; }
    }
}
