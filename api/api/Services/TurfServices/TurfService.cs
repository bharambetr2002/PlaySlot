using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using api.DTOs.Turf;
using api.Models.Entities;
using api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class TurfService
    {
        private readonly ITurfRepository _repository;

        public TurfService(ITurfRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TurfListDto>> GetAllTurfAsync()
        {
            var turfs = await _repository.GetAllTurfAsync();

            return turfs.Select(dto => new TurfListDto
            {
                Name = dto.Name,
                OwnerContactName = dto.OwnerContactName,
                ContactNumber = dto.ContactNumber,
                City = dto.City,
                OriginDate = dto.OriginDate,

            }).ToList();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted)
                return false;

            await _repository.SaveChangesAsync();
            return true;
        }
        public async Task<TurfDetailDto?> GetTurfByIdAsync(int id)
        {
            var turf = await _repository.GetTurfByIdAsync(id);

            if (turf == null)
                return null;

            return new TurfDetailDto
            {
                Id = turf.Id,
                Name = turf.Name,
                OwnerContactName = turf.OwnerContactName,
                ContactNumber = turf.ContactNumber,
                City = turf.City,
                OriginDate = turf.OriginDate,
                Rating = turf.Rating,
            };
        }

        public async Task<bool> UpdateAsync(int id, TurfDetailDto dto)
        {
            var turf = await _repository.UpdateByTurfIdAsync(id);
            if (turf == null)
            {
                return false;
            }
            else
            {
                turf.Name = dto.Name;
                turf.Name = dto.Name;
                turf.OwnerContactName = dto.OwnerContactName;
                turf.ContactNumber = dto.ContactNumber;
                turf.City = dto.City;
            }
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task CreateAsync(CreateTurfDto dto)
        {
            var turf = new Turf
            {
                Name = dto.Name,
                OwnerContactName = dto.OwnerContactName,
                ContactNumber = dto.ContactNumber,
                City = dto.City,
                OriginDate = dto.OriginDate,
                // OpensAt = dto.OpensAt,
                // ClosesAt = dto.ClosesAt
            };

            await _repository.AddAsync(turf);
            await _repository.SaveChangesAsync();
        }
    }
}
