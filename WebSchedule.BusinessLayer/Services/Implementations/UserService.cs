using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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

namespace WebSchedule.BusinessLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Dependencies

        private readonly IDataProvider _dataProvider;
        private readonly IMapper _mapper;

        #endregion


        #region .ctor

        public UserService(IDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        #endregion


        #region Interface

        public async Task<ICollection<UserDto>> GetAllUsersAsync()
        {
            var users = await _dataProvider.Set<User>().ToListAsync();

            var userDto = _mapper.Map<UserDto>(users.First());

            throw new NotImplementedException();
        }

        public async Task<bool> AuthorizeAsync(string jwt, RightsDto claimDto)
        {
            var claim = _mapper.Map<Rights>(claimDto);

            return await _dataProvider.Set<User>()
                .AnyAsync(x => x.Jwt == jwt && x.Role.Rights.Any(r => r.Name == claimDto.Name));
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            bool alreadyExists = await _dataProvider.Set<User>().AnyAsync(u => u.Username == model.Username);
            if (alreadyExists)
                throw new UserAlreadyExistsException(HttpStatusCode.Conflict);

            var requestedRole = await _dataProvider.Set<Role>().FirstOrDefaultAsync(r => r.Name == model.Role);
            if (requestedRole == null)
                throw new NoSuchRoleException(HttpStatusCode.NotFound);


            string hashedPassword = HashPassword(model.Password);
            string jwt = GenerateToken(model.Username + "TOKEN_APP_SECRET_WEB_SCHEDULE");

            await _dataProvider.AddAsync(new User { Username = model.Username, Password = hashedPassword, Role = requestedRole, Jwt = jwt});
            await _dataProvider.SaveAsync();

            return jwt;
        }

        public async Task<string> AuthenticateUserAsync(LoginModel model)
        {
            string hashedPassword = this.HashPassword(model.Password);

            var user = await _dataProvider.Set<User>()
                .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == hashedPassword);

            return user.Jwt;
        }

        public async Task<UserDto> AuthenticateUserAsync(string jwt)
        {
            var user = await _dataProvider.Set<User>().FirstOrDefaultAsync(u => u.Jwt == jwt);

            if (user == null)
                throw new EntityNotFoundException($"User with jwt: {jwt} doesn't exist.", HttpStatusCode.NotFound);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> HasRightToAsync(string jwt, string right)
        {
            var user = await _dataProvider.Set<User>().FirstOrDefaultAsync(u => u.Jwt == jwt);

            if (user == null)
                throw new NoSuchUserException(HttpStatusCode.Unauthorized);

            return user.Role.Rights.Any(r => r.Name == right);
        }

        #endregion


        #region Private methods
        
        private string GenerateToken(string key)
        {
            var resultBytes = new byte[64];

            var keyBytes = Encoding.ASCII.GetBytes(key + "APP_SECRET_WEB_SCHEDULE");

            using (var hmac = new HMACSHA256(keyBytes))
            {
                resultBytes = hmac.ComputeHash(resultBytes);
            }

            return resultBytes.ToConcatString();
        }

        private string HashPassword(string password)
        {
            var hasher = new SHA1CryptoServiceProvider();
            return hasher.ComputeHash(Encoding.ASCII.GetBytes(password)).ToConcatString();
        }

        #endregion
    }
}
