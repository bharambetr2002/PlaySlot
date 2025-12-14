using System.Threading.Tasks;
using api.Data;
using api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TurfRepository : ITurfRepository
    {
        private readonly ApplicationDbContext _context;

        public TurfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Turf turf)
        {
            await _context.Turfs.AddAsync(turf);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var turf = await _context.Turfs.FindAsync(id);

            if (turf == null)
                return false;

            _context.Turfs.Remove(turf);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<Turf>> GetAllTurfAsync()
        {
            return await _context.Turfs.ToListAsync();
        }

        public async Task<Turf?> GetTurfByIdAsync(int id)
        {
            return await _context.Turfs.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Turf?> UpdateByTurfIdAsync(int id)
        {
            return await _context.Turfs.FindAsync(id);
        }
    }
}
