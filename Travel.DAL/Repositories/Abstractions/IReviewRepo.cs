using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IReviewRepo
    {
        Task<List<Review>> GetAllAsync();
        Task<(bool, string?)> CreateAsync(Review r);
        Task<Review?> GetIdAsync(int id);
        Task<(bool, string?)> DeleteAsync(int id);
        Task<(bool, string?)> UpdateAsync(Review r, int id);
    }
}
