﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Services.Interfaces;
using WebSchedule.Infrastructure.Entities;

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
        [Authorize(Roles = nameof(RightsDto.None))]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();

            if (!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        #endregion
    }
}
