using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Services.Exceptions;
using WebSchedule.BusinessLayer.Services.Interfaces;
using WebSchedule.Infrastructure.Entities;
using WebSchedule.Infrastructure.Interfaces;

namespace WebSchedule.BusinessLayer.Services.Implementations
{
    public class ClassroomService : IClassroomService
    {
        #region Dependencies

        private readonly IDataProvider _dataProvider;
        private readonly IMapper _mapper;

        #endregion


        #region .ctor

        public ClassroomService(IDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        #endregion


        #region Public methods

        public async Task CreateClassroomAsync(ClassroomDto classroomDto)
        {
            var classroom = _mapper.Map<Classroom>(classroomDto);

            await _dataProvider.AddAsync(classroomDto);
            await _dataProvider.SaveAsync();
        }

        public async Task RemoveClassRoomAsync(int classRoomId)
        {
            var classroom = await _dataProvider.Set<Classroom>()
                .FirstOrDefaultAsync(c => c.Id == classRoomId);
            _dataProvider.Remove(classroom);
            await _dataProvider.SaveAsync();
        }

        public async Task<ClassroomDto> GetClassroomAsync(int id)
        {
            var classroom = await _dataProvider.Set<Classroom>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<ClassroomDto>(classroom);
        }

        #endregion
    }
}
