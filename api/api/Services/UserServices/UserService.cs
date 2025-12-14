using System.Diagnostics.Eventing.Reader;
using api.Models.DTOs.User;
using api.Models.Entities;
using api.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace api.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CreateUserDTO>> GetAllUsersAsync()
    {
        var users = await _repository.GetAllUserAsync();

        return users.Select(user => new CreateUserDTO
        {
            UserName = user.UserName,
            UserContactNumber = user.UserContactNumber,
            UserLocation = user.UserLocation
        }).ToList();
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

    public async Task<bool> DeleteUserByIdAsync(int id)
    {
        return await _repository.DeleteUserByIdAsync(id);
    }

    public async Task<CreateUserDTO?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
            return null;

        return new CreateUserDTO
        {
            UserName = user.UserName,
            UserContactNumber = user.UserContactNumber,
            UserLocation = user.UserLocation
        };
    }

    public async Task<bool> UpdateUserAsync(int id, CreateUserDTO dto)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
            return false;

        user.UserName = dto.UserName;
        user.UserContactNumber = dto.UserContactNumber;
        user.UserLocation = dto.UserLocation;

        await _repository.SaveChangesAsync();
        return true;
    }



}
