using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.FieldStudies;
using UniversityManager.Infrastructure.Services.Interfaces;

namespace UniversityManager.Infrastructure.Handlers.FieldStudies
{
    public class CreateFieldStudyHandler : ICommandHandler<CreateFieldStudy>
    {
        private readonly IFieldStudyService _fieldStudyService;

        public CreateFieldStudyHandler(IFieldStudyService fieldStudyService)
        {
            _fieldStudyService = fieldStudyService;
        }

        public async Task Handle(CreateFieldStudy command)
        {
            await _fieldStudyService.Add(command.Name, command.FacultyId);
        }
    }
}
