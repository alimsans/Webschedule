using System.Collections.Generic;
using System.Threading.Tasks;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Models.WebApi;
using WebSchedule.Infrastructure.Entities;

namespace WebSchedule.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetAllUsersAsync();
        Task<bool> AuthorizeAsync(string jwt, RightsDto claimDto);
        Task<string> RegisterAsync(RegisterModel model);
        Task<string> AuthenticateUserAsync(LoginModel model);
        Task<UserDto> AuthenticateUserAsync(string jwt);
        Task<bool> HasRightToAsync(string jwt, string right);
    }
}
