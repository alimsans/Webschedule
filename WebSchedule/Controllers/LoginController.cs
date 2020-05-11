using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Models.WebApi;
using WebSchedule.BusinessLayer.Services.Interfaces;

namespace WebSchedule.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
            :base(userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RespondWithPageAnonymous("login.html");
        }

        [HttpGet]
        [Route("~/api/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return await RespondAnonymousAsync(_userService.AuthenticateUserAsync(model));
        }
    }
}