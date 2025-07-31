using Microsoft.EntityFrameworkCore;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class PlaceRepo : IPlaceRepo
    {
        private readonly ApplicationDbContext _context;
        public PlaceRepo()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<(bool, string?)> CreateAsync(Place p)
        {
            if (p == null)
            {
                return (false, "Place cannot be null.");
            }

            try
            {
                await _context.Places.AddAsync(p);
                await _context.SaveChangesAsync();
                return (true, "Place created successfully.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> DeleteAsync(int id)
        {
            try
            {
                var place = await _context.Places.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                if (place == null)
                    return (false, "Place cannot be null.");

                place.SetDeleted();
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            
        }

        public async Task<List<Place>> GetAllAsync()
        {
             return await _context.Places.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Place?> GetIdAsync(int id)
        {
            return await _context.Places.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<(bool, string?)> UpdateAsync(Place p, int id)
        {
            try
            {
                var _place = await _context.Places.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                if (_place == null)
                    return (false, "Place cannot be null.");

                _place.UpdatePlace(p.Name, p.Country, p.City, p.Description, p.PlaceType);
                _place.SetModified();
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
