using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSchedule.BusinessLayer.Helpers.Extensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Models.WebApi;
using WebSchedule.BusinessLayer.Services.Exceptions;
using WebSchedule.BusinessLayer.Services.Interfaces;
using WebSchedule.Infrastructure.Entities;
using WebSchedule.Infrastructure.Interfaces;
using static WebSchedule.BusinessLayer.Helpers.Constants.StringConstants;

namespace WebSchedule.BusinessLayer.Services.Implementations
{
    public class ClassService : IClassService
    {
        #region Dependencies

        private readonly IDataProvider _dataProvider;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        #endregion


        #region .ctor

        public ClassService(IDataProvider dataProvider, IUserService userService, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _userService = userService;
            _mapper = mapper;
        }

        #endregion


        #region Public methods

        public async Task<IEnumerable<ClassDto>> GetOwnClasses(string jwt)
        {
            //if (!await _userService.HasRightToAsync(jwt, ViewOwnSchedule))
            //    throw new NotEnoughRights(HttpStatusCode.Forbidden);

            var user = await _dataProvider.Set<User>()
                .FirstOrDefaultAsync(u => u.Jwt == jwt);

            var classes = await _dataProvider.Set<Class>()
                .Where(c => c.Group.Students.Contains(user))
                .ToListAsync();

            if (classes == null || classes.Any())
                return null;

            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<IEnumerable<ClassDto>> GetClassByGroupAsync(string groupName)
        {
            //if (!await _userService.HasRightToAsync(jwt, ViewScheduleByGroup))
            //    throw new NotEnoughRights(HttpStatusCode.Forbidden);

            var classes = await _dataProvider.Set<Class>()
                .Where(c => c.Group.Name.Contains(groupName))
                .ToListAsync();
            if (classes == null || !classes.Any())
                throw new EntityNotFoundException(HttpStatusCode.NotFound);

            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<IEnumerable<ClassDto>> GetClassByClassroomAsync(int classroomNumber)
        {
            //if (!await _userService.HasRightToAsync(jwt, ViewScheduleByClassroom))
            //    throw new NotEnoughRights(HttpStatusCode.Forbidden);

            var classes = await _dataProvider.Set<Class>()
                .Where(c => c.Classroom.Number == classroomNumber)
                .ToListAsync();
            if (classes == null || !classes.Any())
                throw new EntityNotFoundException(HttpStatusCode.NotFound);

            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<IEnumerable<ClassDto>> GetClassByTeacherAsync(string teacherName)
        {
            //if (!await _userService.HasRightToAsync(jwt, ViewScheduleByTeacher))
            //    throw new NotEnoughRights(HttpStatusCode.Forbidden);

            var classes = await _dataProvider.Set<Class>()
                .Where(c => c.Teacher.Name.Contains(teacherName))
                .ToListAsync();
            if (classes == null || !classes.Any())
                throw new EntityNotFoundException(HttpStatusCode.NotFound);

            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<IEnumerable<ClassDto>> GetClassByDisciplineAsync(string disciplineName)
        {
            //if (!await _userService.HasRightToAsync(jwt, ViewScheduleByDiscipline))
            //    throw new NotEnoughRights(HttpStatusCode.Forbidden);

            var classes = await _dataProvider.Set<Class>()
                .Where(c => c.Discipline.Name.Contains(disciplineName))
                .ToListAsync();
            if (classes == null || !classes.Any())
                throw new EntityNotFoundException(HttpStatusCode.NotFound);

            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task CreateClassAsync(NewClassModel model)
        {
            var @class = _mapper.Map<Class>(model);
            await _dataProvider.AddAsync(@class);
            await _dataProvider.SaveAsync();
        }

        #endregion
    }
}
