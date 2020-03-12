using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSchedule.BusinessLayer.Models;
using WebSchedule.BusinessLayer.Services.Interfaces;
using WebSchedule.Infrastructure.Entities;
using WebSchedule.Infrastructure.Interfaces;

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

            var usersDto = _mapper.Map<ICollection<User>, ICollection<UserDto>>(users);

            return usersDto;
        }
    }
}
