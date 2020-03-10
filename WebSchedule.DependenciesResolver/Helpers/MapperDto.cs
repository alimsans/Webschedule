using AutoMapper;
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
                cfg.CreateMap<ClassDto, Class>();
                cfg.CreateMap<ClassroomDto, Classroom>();
                cfg.CreateMap<DisciplineDto, Discipline>();
                cfg.CreateMap<GroupDto, Group>();
                cfg.CreateMap<LessonDto, Lesson>();
                cfg.CreateMap<RightsDto, Rights>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<WeekDayDto, WeekDay>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
