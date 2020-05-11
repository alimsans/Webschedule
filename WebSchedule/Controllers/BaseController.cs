using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Services.Exceptions;
using WebSchedule.BusinessLayer.Services.Interfaces;
using static WebSchedule.BusinessLayer.Helpers.Constants.StringConstants;

namespace WebSchedule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected readonly IUserService UserService;

        protected bool IsAuthorized { get; private set; }
        protected new UserDto User { get; private set; }
        protected RightsDto Claim { get; private set; } = Anonymous.ToRightsDto();

        protected BaseController(IUserService userService)
        {
            UserService = userService;
        }

        protected async Task<IActionResult> RespondAsync<T>(Task<T> task, string jwt, RightsDto claim)
        {
            Claim = claim;
            IsAuthorized = await AuthorizeAsync(jwt);
            if (!IsAuthorized)
                return Unauthorized();

            try
            {
                return Ok(await task);
            }
            catch (ClientDiscoverableException e)
            {
                return StatusCode((int)e.StatusCode);
            }
            catch (Exception e)
            {
                //log exception
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        protected async Task<IActionResult> RespondAsync(Task task, string jwt, RightsDto claim)
        {
            Claim = claim;
            IsAuthorized = await AuthorizeAsync(jwt);
            if (!IsAuthorized)
                return Unauthorized();

            try
            {
                await task;
                return Ok();
            }
            catch (ClientDiscoverableException e)
            {
                return StatusCode((int)e.StatusCode);
            }
            catch (Exception e)
            {
                //log exception
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }


        protected IActionResult RespondWithPageAnonymous(string path)
        {
            try
            {
                var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\html\\" + path);

                return PhysicalFile(file, "text/html");
            }
            catch (ClientDiscoverableException e)
            {
                return StatusCode((int) e.StatusCode);
            }
            catch (Exception e)
            {
                //log exception
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        protected async Task<IActionResult> RespondWithPageAsync(string path, string jwt, RightsDto claim)
        {
            Claim = claim;
            IsAuthorized = await AuthorizeAsync(jwt);
            if (!IsAuthorized)
                return Unauthorized();

            try
            {
                var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\html\\" + path);

                return PhysicalFile(file, "text/html");
            }
            catch (ClientDiscoverableException e)
            {
                return StatusCode((int)e.StatusCode);
            }
            catch (Exception e)
            {
                //log exception
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        protected IActionResult RespondAnonymous<T>(Func<T> func)
        {
            try
            {
                return Ok(func.Invoke());
            }
            catch (ClientDiscoverableException e)
            {
                return StatusCode((int)e.StatusCode);
            }
            catch (Exception e)
            {
                //log exception
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        protected async Task<IActionResult> RespondAnonymousAsync<T>(Task<T> task)
        {
            try
            {
                return Ok(await task);
            }
            catch (ClientDiscoverableException e)
            {
                return StatusCode((int)e.StatusCode);
            }
            catch (Exception e)
            {
                //log exception
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        protected async Task<UserDto> AuthenticateUserAsync(string jwt)
        {
            var user = await UserService.AuthenticateUserAsync(jwt);


        }

        private async Task<bool> AuthorizeAsync(string jwt)
        {
            return await UserService.AuthorizeAsync(jwt, Claim);
        }
    }
}
