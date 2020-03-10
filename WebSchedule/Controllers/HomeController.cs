using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Services.Interfaces;

namespace WebSchedule.API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        #region Dependencies

        private readonly IUserService _userService;

        #endregion

        #region .ctor

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Controllers

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        #endregion
    }
}
