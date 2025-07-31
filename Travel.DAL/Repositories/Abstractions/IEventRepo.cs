using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IEventRepo
    {
        (bool, string?) Create(Event eventpram);
        Event GetId(int id);
        List<Event> GetAll();
        (bool, string?) Delete(int id);
        (bool, string?) Update(Event eventpram, int id);
        Task<(bool, string?)> CreateAsync(Event eventpram);
        Task<Event?> GetIdAsync(int id);
        Task<List<Event>> GetAllAsync();
        Task<(bool, string?)> DeleteAsync(int id);
        Task<(bool, string?)> UpdateAsync(Event eventpram, int id);
    }
}
