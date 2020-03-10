using System.Collections.Generic;
using System.Threading.Tasks;
using WebSchedule.BusinessLayer.Models;

namespace WebSchedule.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserDto>> GetAllUsersAsync();
    }
}
