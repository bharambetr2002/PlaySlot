using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Entities;

namespace api.Repositories

{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> UpdateUserAsync(int id);
        Task<bool> DeleteUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}