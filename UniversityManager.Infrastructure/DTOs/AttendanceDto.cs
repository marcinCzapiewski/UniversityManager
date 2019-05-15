using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Infrastructure.DTOs
{
    public class AttendanceDto
    {
        public Guid Id { get; protected set; }
        public Guid LectureId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public bool Present { get; protected set; }
    }
}
