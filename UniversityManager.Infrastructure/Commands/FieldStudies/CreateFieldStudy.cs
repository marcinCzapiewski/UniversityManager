using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Infrastructure.Commands.FieldStudies
{
    public class CreateFieldStudy : ICommand
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Guid FacultyId { get; protected set; }
    }
}
