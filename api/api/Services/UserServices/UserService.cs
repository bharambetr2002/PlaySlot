using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.DTOs.User;
using api.Models.Entities;
using api.Repositories;

namespace api.Services

{
    public class UserService
    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUserAsync(CreateUserDTO user)
        {
            var demouser = new User
            {
                UserName = user.UserName,
                UserContactNumber = user.UserContactNumber,
                UserLocation = user.UserLocation,
            };
            await _repository.AddUserAsync(demouser);
            await _repository.SaveChangesAsync();
        }
    }
}