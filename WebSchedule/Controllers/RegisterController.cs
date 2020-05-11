using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Models.WebApi;
using WebSchedule.BusinessLayer.Services.Interfaces;
using static WebSchedule.BusinessLayer.Helpers.Constants.StringConstants;

namespace WebSchedule.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : BaseController
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
            :base(userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model">Registration model.</param>
        /// <returns>Token.</returns>
        [HttpPost]
        [Route("~/api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            return await RespondAnonymousAsync(_userService.RegisterAsync(model));
        }
    }
}