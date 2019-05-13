using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Core.Domain
{
    public class StudySubject
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public FieldStudy FieldStudy { get; protected set; }
        public int Semester { get; protected set; }

        public StudySubject()
        {

        }
    }
}
