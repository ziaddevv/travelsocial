using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    internal interface ITripRepo
    {
        Task<List<Trip>> GetAllAsync();
        Task<(bool, string?)> CreateAsync(Trip t);
        Task<Trip?> GetIdAsync(int id);
        Task<(bool, string?)> DeleteAsync(int id);
        Task<(bool, string?)> UpdateAsync(Trip t, int id);
    }
}
