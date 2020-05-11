using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Services.Interfaces;
using static WebSchedule.BusinessLayer.Helpers.Constants.StringConstants;

namespace WebSchedule.API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        #region Dependencies

        private readonly IUserService _userService;

        #endregion


        #region .ctor

        public HomeController(IUserService userService) 
            : base(userService)
        {
            _userService = userService;
        }

        #endregion


        #region Controllers

        [HttpGet]
        public async Task<IActionResult> Index([FromHeader] string jwt)
        {
            return await RespondWithPageAsync("index.html", jwt, Anonymous.ToRightsDto());
        }

        #endregion
    }
}
