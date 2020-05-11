using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSchedule.BusinessLayer.Models;

namespace WebSchedule.BusinessLayer.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateGroupAsync();
        Task DeleteGroupAsync();
        Task AddStudentsAsync(ICollection<UserDto> students);
        Task RemoveStudentsAsync(ICollection<UserDto> students);
    }
}
