using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.FieldStudies;
using UniversityManager.Infrastructure.Services.Interfaces;

namespace UniversityManager.Api.Controllers
{
    public class FieldStudiesController : BaseController
    {
        private readonly IFieldStudyService _fieldStudyService;

        public FieldStudiesController(ICommandDispatcher commandDispatcher, IFieldStudyService fieldStudyService)
            : base(commandDispatcher)
        {
            _fieldStudyService = fieldStudyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateFieldStudy command)
        {
            await Dispatch(command);

            return Created($"fieldStudies/{command.Name}", null);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var fieldStudy = await _fieldStudyService.Get(name);

            if (fieldStudy == null)
                return NotFound();

            return Json(fieldStudy);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fieldStudies = await _fieldStudyService.Browse();

            return Json(fieldStudies);
        }
    }
}
