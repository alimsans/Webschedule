using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models.WebApi;
using WebSchedule.BusinessLayer.Services.Interfaces;
using static WebSchedule.BusinessLayer.Helpers.Constants.StringConstants;

namespace WebSchedule.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : BaseController
    {
        private readonly IClassService _classService;


        public ClassController(IUserService userService, IClassService classService) 
            : base(userService)
        {
            _classService = classService;
        }

        [HttpPost]
        [Route("~/api/class")]
        public async Task<IActionResult> CreateClass([FromHeader]string jwt, [FromBody] NewClassModel model)
        {
            return await RespondAsync(_classService.CreateClassAsync(model),
                jwt,
                CanEdit.ToRightsDto());
        }

        [HttpGet]
        [Route("~/api/class/own")]
        public async Task<IActionResult> GetOwnClasses([FromHeader]string jwt)
        {
            return await RespondAsync(
                _classService.GetOwnClasses(jwt),
                jwt,
                ViewOwnSchedule.ToRightsDto());
        }

        [HttpGet]
        [Route("~/api/class/group/{groupName}")]
        public async Task<IActionResult> GetClassByGroup([FromHeader]string jwt, string groupName)
        {
            return await RespondAsync(_classService.GetClassByGroupAsync(groupName),
                jwt,
                ViewScheduleByGroup.ToRightsDto());
        }

        [HttpGet]
        [Route("~/api/class/group/{classroom}")]
        public async Task<IActionResult> GetClassByClassroom([FromHeader]string jwt, int classroomNumber)
        {
            return await RespondAsync(_classService.GetClassByClassroomAsync(classroomNumber),
                jwt,
                ViewScheduleByClassroom.ToRightsDto());
        }

        [HttpGet]
        [Route("~/api/class/group/{teacherName}")]
        public async Task<IActionResult> GetClassByTeacher([FromHeader]string jwt, string teacherName)
        {
            return await RespondAsync(_classService.GetClassByTeacherAsync(teacherName),
                jwt,
                ViewScheduleByTeacher.ToRightsDto());
        }

    }
}
