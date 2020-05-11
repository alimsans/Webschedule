using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Models.WebApi;

namespace WebSchedule.BusinessLayer.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetOwnClasses(string jwt);
        Task<IEnumerable<ClassDto>> GetClassByGroupAsync(string groupName);
        Task<IEnumerable<ClassDto>> GetClassByClassroomAsync(int classroomNumber);
        Task<IEnumerable<ClassDto>> GetClassByTeacherAsync(string teacherName);
        Task<IEnumerable<ClassDto>> GetClassByDisciplineAsync(string disciplineName);
        Task CreateClassAsync(NewClassModel model);
    }
}
