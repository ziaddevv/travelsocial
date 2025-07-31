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
    class GroupRepo : IGroupRepo
    {
        private readonly ApplicationDbContext dp;

        public GroupRepo(ApplicationDbContext dp)
        {
            this.dp = dp;
        }


        public (bool, string?) Create(Group group)
        {
            try
            {
                dp.Groups.Add(group);
                dp.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Create failed: {ex.Message}");
            }
        }

        public async Task<(bool, string?)> CreateAsync(Group group)
        {
            try
            {
                await dp.Groups.AddAsync(group);
                await dp.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Create failed: {ex.Message}");
            }
        }


        public (bool, string?) Delete(int id)
        {
            try
            {
                var group = dp.Groups
                    .Include(g => g.Members)
                    .Include(g => g.Events)
                    .FirstOrDefault(g => g.GroupId == id && !g.IsDeleted);

                if (group == null)
                    return (false, "Group not found or already deleted");

                foreach (var member in group.Members.Where(m => !m.IsDeleted))
                {
                    member.SetDeleted();
                }

                foreach (var ev in group.Events.Where(e => !e.IsDeleted))
                {
                    ev.SetDeleted();
                }

                group.SetDeleted();

                dp.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Delete failed: {ex.Message}");
            }
        }


        public async Task<(bool, string?)> DeleteAsync(int id)
        {
            try
            {
                var group = await dp.Groups
                    .Include(g => g.Members)
                    .Include(g => g.Events)
                    .FirstOrDefaultAsync(g => g.GroupId == id && !g.IsDeleted);

                if (group == null)
                    return (false, "Group not found or already deleted");

                foreach (var member in group.Members.Where(m => !m.IsDeleted))
                {
                    member.SetDeleted();
                }

                // delete events
                foreach (var ev in group.Events.Where(e => !e.IsDeleted))
                {
                    ev.SetDeleted();
                }
                //  delete group
                group.SetDeleted();

                
                await dp.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Delete failed: {ex.Message}");
            }
        }


        public List<Group> GetAll()
        {
            try
            {
                return dp.Groups
               .Where(g => !g.IsDeleted)
               .Include(g => g.Members.Where(m => !m.IsDeleted))
               .Include(g => g.Events.Where(e => !e.IsDeleted))
               .ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public async Task<List<Group>> GetAllAsync()
        {
            try
            {
                return await dp.Groups
               .Where(g => !g.IsDeleted)
               .Include(g => g.Members.Where(m => !m.IsDeleted))
               .Include(g => g.Events.Where(e => !e.IsDeleted))
               .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public async Task<Group?> GetIdAsync(int id)
        {
            try
            {
                return await dp.Groups
                .Where(g => g.GroupId == id && !g.IsDeleted)
                .Include(g => g.Members.Where(m => !m.IsDeleted))
                .Include(g => g.Events.Where(e => !e.IsDeleted))
                .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public (bool, string?) Update(Group group, int id)
        {
            try
            {
                var existingGroup = dp.Groups.FirstOrDefault(g => g.GroupId == id && !g.IsDeleted);

                if (existingGroup == null)
                    return (false, "Group not found or already deleted");

                existingGroup.UpdateGroup(group.Name, group.Description, group.Privacy);

                dp.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Update failed: {ex.Message}");
            }
        }


        public async Task<(bool, string?)> UpdateAsync(Group group, int id)
        {
            try
            {
                var existingGroup = await dp.Groups.FirstOrDefaultAsync(g => g.GroupId == id && !g.IsDeleted);

                if (existingGroup == null)
                    return (false, "Group not found or already deleted");


                existingGroup.UpdateGroup(group.Name,group.Description,group.Privacy);

                await dp.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Update failed: {ex.Message}");
            }
        }


        public Group GetId(int id)
        {
            return dp.Groups
                .Where(g => g.GroupId == id && !g.IsDeleted)
                .Include(g => g.Members.Where(m => !m.IsDeleted))
                .Include(g => g.Events.Where(e => !e.IsDeleted))
                .FirstOrDefault();
        }

    }
}
