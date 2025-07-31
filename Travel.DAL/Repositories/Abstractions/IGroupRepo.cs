
using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IGroupRepo
    {
        (bool, string?) Create(Group group);
        Group GetId(int id);
        List<Group> GetAll();
        (bool, string?) Delete(int id);
        (bool, string?) Update(Group group, int id);
        Task<(bool, string?)> CreateAsync(Group group);
        Task<Group?> GetIdAsync(int id);
        Task<List<Group>> GetAllAsync();
        Task<(bool, string?)> DeleteAsync(int id);
        Task<(bool, string?)> UpdateAsync(Group group, int id);
    }
}
