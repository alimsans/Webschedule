using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.Infrastructure.Entities;

namespace WebSchedule.DependenciesResolver.Helpers
{
    internal static class MapperDto
    {
        internal static IMapper Mapper { get; }

        static MapperDto()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassDto, Class>().ReverseMap();
                cfg.CreateMap<ClassroomDto, Classroom>().ReverseMap();
                cfg.CreateMap<DisciplineDto, Discipline>().ReverseMap();
                cfg.CreateMap<GroupDto, Group>().ReverseMap();
                cfg.CreateMap<LessonDto, Lesson>().ReverseMap();
                cfg.CreateMap<RightsDto, Rights>().ReverseMap();
                cfg.CreateMap<RoleDto, Role>().ReverseMap();
                cfg.CreateMap<UserDto, User>().ReverseMap();
                cfg.CreateMap<WeekDayDto, WeekDay>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}
