using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.StudySubjects;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Infrastructure.Handlers.StudySubjects
{
    public class CreateStudySubjectHandler : ICommandHandler<CreateStudySubject>
    {
        private readonly IStudySubjectService _studySubjectService;

        public CreateStudySubjectHandler(IStudySubjectService studySubjectService)
        {
            _studySubjectService = studySubjectService;
        }

        public async Task Handle(CreateStudySubject command)
        {
            await _studySubjectService.Add(command.Name, command.FieldStudyId, command.Semester);
        }
    }
}
