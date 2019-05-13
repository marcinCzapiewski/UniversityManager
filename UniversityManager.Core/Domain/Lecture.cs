using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Core.Domain
{
    public class Lecture
    {
        public Guid Id { get; protected set; }
        public Lecturer Lecturer { get; protected set; }
        public LectureRoom LectureRoom { get; protected set; }
        public StudySubject StudySubject { get; protected set; }
        public DateTime When { get; protected set; }

        protected Lecture()
        {

        }
    }
}
