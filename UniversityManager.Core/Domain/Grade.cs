using System;

namespace UniversityManager.Core.Domain
{
    public class Grade
    {
        public Guid Id { get; protected set; }
        public Student Student { get; protected set; }
        public Lecturer Lecturer { get; protected set; }
        public StudySubject StudySubject { get; protected set; }

        protected Grade()
        {

        }
    }
}
