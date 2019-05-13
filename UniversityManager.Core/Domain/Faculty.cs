using System;
using System.Collections.Generic;

namespace UniversityManager.Core.Domain
{
    public class Faculty
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public List<FieldStudy> FieldStudies { get; protected set; }

        protected Faculty()
        {

        }
    }
}
