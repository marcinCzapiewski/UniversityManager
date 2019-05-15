using System;

namespace UniversityManager.Core.Domain
{
    public class Attendance
    {
        public Guid Id { get; protected set; }
        public Lecture Lecture { get; protected set; }
        public Student Student { get; protected set; }
        public bool Present { get; protected set; }

        protected Attendance()
        {

        }

        public Attendance(Lecture lecture, Student student, bool present)
        {
            Id = Guid.NewGuid();
            Lecture = lecture;
            Student = student;
            Present = present;
        }
    }
}
