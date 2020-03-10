using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSchedule.BusinessLayer.Services.Interfaces;
using WebSchedule.Infrastructure.Entities;
using WebSchedule.Infrastructure.Interfaces;
using UserDto = WebSchedule.BusinessLayer.Models.UserDto;

namespace WebSchedule.BusinessLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IMapper _mapper;


        public UserService(IDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDto>> GetAllUsersAsync()
        {
            var users = await _dataProvider.Set<User>().ToListAsync();

            var userDto = _mapper.Map<UserDto>(users.First());

            return null;
        }
    }
}
