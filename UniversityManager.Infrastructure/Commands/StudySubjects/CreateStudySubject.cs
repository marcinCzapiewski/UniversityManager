using System;

namespace UniversityManager.Infrastructure.Commands.StudySubjects
{
    public class CreateStudySubject : ICommand
    {
        public string Name { get; protected set; }
        public Guid FieldStudyId { get; protected set; }
        public int Semester { get; protected set; }
    }
}
