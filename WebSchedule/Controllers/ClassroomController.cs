using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Services.Interfaces;
using static WebSchedule.BusinessLayer.Helpers.Constants.StringConstants;

namespace WebSchedule.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : BaseController
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IUserService userService, IClassroomService classroomService) 
            : base(userService)
        {
            _classroomService = classroomService;
        }
        
        [HttpGet]
        [Route("~/api/classroom")]
        public async Task<IActionResult> GetClassroom([FromHeader]string jwt, [FromHeader]int id)
        {
            return await RespondAsync(_classroomService.GetClassroomAsync(id), 
                jwt, 
                ViewOwnSchedule.ToRightsDto());
        }

        [HttpPost]
        [Route("~/api/classroom")]
        public async Task<IActionResult> CreateClassroom([FromHeader]string jwt, [FromBody]ClassroomDto classroom)
        {
            return await RespondAsync(
                _classroomService.CreateClassroomAsync(classroom),
                jwt,
                CanEdit.ToRightsDto());
        }
    }
}
