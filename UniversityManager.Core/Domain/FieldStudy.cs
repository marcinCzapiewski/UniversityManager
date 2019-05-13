using System;
using System.Collections.Generic;

namespace UniversityManager.Core.Domain
{
    public class FieldStudy
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Faculty Faculty { get; protected set; }
        public List<StudySubject> StudySubjects{ get; protected set; }

        protected FieldStudy()
        {

        }
    }
}
