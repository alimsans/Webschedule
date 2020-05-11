using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.Infrastructure.Entities;

namespace WebSchedule.BusinessLayer.Services.Interfaces
{
    public interface IScheduleService
    {
        Task CreateClass(ClassDto classDto);

        Task<ICollection<Class>> GetClassesByRoomAsync(int classRoomId);
        Task<ICollection<Class>> GetClassesByGroupAsync(int groupNum);
        Task<ICollection<Class>> GetClassesByTeacherAsync(int teacherId);
        Task<ICollection<Class>> GetClassesByDisciplineAsync(int disciplineId);
    }
}
