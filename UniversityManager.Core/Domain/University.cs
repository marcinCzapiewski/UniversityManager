using System;
using System.Collections.Generic;

namespace UniversityManager.Core.Domain
{
    public class University
    {
        public Guid Id { get; protected set; }
        public List<Faculty> Faculties { get; protected set; }

        protected University()
        {

        }
    }
}
