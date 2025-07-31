using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    internal interface IPlaceRepo
    {
        Task<List<Place>> GetAllAsync();
        Task<(bool, string?)> CreateAsync(Place p);
        Task<Place?> GetIdAsync(int id);
        Task<(bool, string?)> DeleteAsync(int id);
        Task<(bool, string?)> UpdateAsync(Place p, int id);
    }
}
