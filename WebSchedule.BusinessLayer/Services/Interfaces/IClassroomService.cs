using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSchedule.BusinessLayer.Models;

namespace WebSchedule.BusinessLayer.Services.Interfaces
{
    public interface IClassroomService
    {
        Task CreateClassroomAsync(ClassroomDto classroomDto);
        Task RemoveClassRoomAsync(int classRoomId);
        Task<ClassroomDto> GetClassroomAsync(int id);
    }
}
