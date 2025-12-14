using System.Threading.Tasks;
using api.Models.Entities;

namespace api.Repositories

{
    public interface ITurfRepository
    {
        Task<List<Turf>> GetAllTurfAsync();
        Task<Turf?> GetTurfByIdAsync(int Id);
        Task<Turf?> UpdateByTurfIdAsync(int id);
        Task AddAsync(Turf turf);
        Task<bool> DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}