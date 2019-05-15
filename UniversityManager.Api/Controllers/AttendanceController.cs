using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UniversityManager.Infrastructure.Commands;
using UniversityManager.Infrastructure.Commands.Attendances;
using UniversityManager.Infrastructure.Services.Interfaces;

namespace UniversityManager.Api.Controllers
{
    [Authorize]
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(ICommandDispatcher commandDispatcher, IAttendanceService attendanceService)
            : base(commandDispatcher)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateAttendance command)
        {
            await Dispatch(command);

            return Created($"attendances", null);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var attendance = await _attendanceService.Get(id);

            if (attendance == null)
                return NotFound();

            return Json(attendance);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var attendances = await _attendanceService.Browse();

            return Json(attendances);
        }

        [HttpGet]
        public async Task <IActionResult> GetStudentAttendances(Guid studentId)
        {
            var attendances = await _attendanceService.GetStudentAttendences(studentId);

            return Json(attendances);
        }
    }
}
