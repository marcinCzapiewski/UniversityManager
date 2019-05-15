using System;
using UniversityManager.Core.Domain;

namespace UniversityManager.Infrastructure.DTOs
{
    public class FieldStudyDto
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Faculty Faculty { get; protected set; }
    }
}
