using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepo() { _context = new ApplicationDbContext(); }

        public async Task<(bool, string?)> CreateAsync(Review r)
        {
            if (r == null)
            {
                return (false, "Review cannot be null.");
            }

            try
            {
                await _context.Reviews.AddAsync(r);
                await _context.SaveChangesAsync();
                return (true, "Review created successfully.");
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
                var review = await _context.Reviews.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                if (review == null)
                    return (false, "Review cannot be null.");

                review.SetDeleted();
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Review?> GetIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<(bool, string?)> UpdateAsync(Review r, int id)
        {
            try
            {
                var _review = await _context.Reviews.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                if (_review == null)
                    return (false, "Review cannot be null.");

                _review.UpdateReview(r.Rate, r.Text);
                _review.SetModified();
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
