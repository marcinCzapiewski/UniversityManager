using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.StudySubjects;
using UniversityManager.Infrastructure.Services;

namespace UniversityManager.Api.Controllers
{
    [Authorize(Policy = "admin")]
    public class StudySubjectsController : BaseController
    {
        private readonly IStudySubjectService _studySubjectService;

        public StudySubjectsController(ICommandDispatcher commandDispatcher, IStudySubjectService studySubjectService)
            : base(commandDispatcher)
        {
            _studySubjectService = studySubjectService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateStudySubject command)
        {
            await Dispatch(command);

            return Created($"studySubjects/{command.Name}", null);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var studySubject = await _studySubjectService.Get(name);

            if (studySubject == null)
                return NotFound();

            return Json(studySubject);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studySubjects = await _studySubjectService.Browse();

            return Json(studySubjects);
        }


    }
}
