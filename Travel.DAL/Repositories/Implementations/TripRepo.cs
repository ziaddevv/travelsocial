using Microsoft.EntityFrameworkCore;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class TripRepo : ITripRepo
    {
        private readonly ApplicationDbContext _context;
        public TripRepo() { _context = new ApplicationDbContext(); }

        public async Task<(bool, string?)> CreateAsync(Trip t)
        {
            if (t == null)
            {
                return (false, "Trip cannot be null.");
            }

            try
            {
                await _context.Trips.AddAsync(t);
                await _context.SaveChangesAsync();
                return (true, "Trip created successfully.");
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
                var trip = await _context.Trips.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                if (trip == null)
                    return (false, "Trip cannot be null.");

                trip.SetDeleted();
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await _context.Trips.Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<Trip?> GetIdAsync(int id)
        {
            return await _context.Trips.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<(bool, string?)> UpdateAsync(Trip t, int id)
        {
            try
            {
                var _trip = await _context.Trips.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                if (_trip == null)
                    return (false, "Trip cannot be null.");

                _trip.UpdateTrip(t.IsCompleted, t.Title, t.Description, t.TotalCost, t.Start, t.End, t.Transportation);
                _trip.SetModified();
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
