using System;
using UniversityManager.Core.Domain;

namespace UniversityManager.Infrastructure.DTOs
{
    public class StudySubjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; protected set; }
        public Guid FieldStudyId { get; protected set; }
        public int Semester { get; protected set; }
    }
}
