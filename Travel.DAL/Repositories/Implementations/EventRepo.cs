using Microsoft.EntityFrameworkCore;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

public class EventRepo : IEventRepo
{
    private readonly ApplicationDbContext dp;

    public EventRepo(ApplicationDbContext dp)
    {
        this.dp = dp;
    }

    public (bool, string?) Create(Event eventpram)
    {
        try
        {
            dp.Events.Add(eventpram);
            dp.SaveChanges();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public (bool, string?) Delete(int id)
    {
        try
        {
            var _event = dp.Events.FirstOrDefault(a => a.Id == id);
            if (_event == null)
                return (false, "The ID is not correct");

            _event.SetDeleted(); 
            dp.SaveChanges();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public List<Event> GetAll()
    {
        return dp.Events.Where(e => !e.IsDeleted).ToList();
    }

    public Event? GetId(int id)
    {
        return dp.Events.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
    }

    public (bool, string?) Update(Event eventpram, int id)
    {
        try
        {
            var _event = dp.Events.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            if (_event != null)
            {
                _event.UpdateEvent(eventpram.Name, eventpram.City, eventpram.Country, eventpram.EventDate, eventpram.Description);
                _event.SetModified();
                dp.SaveChanges();
                return (true, null);
            }

            return (false, "Event not found");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
    public async Task<(bool, string?)> CreateAsync(Event eventpram)
    {
        try
        {
            await dp.Events.AddAsync(eventpram);
            await dp.SaveChangesAsync();
            return (true, null);
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
            var _event = await dp.Events.FirstOrDefaultAsync(a => a.Id == id);
            if (_event == null)
                return (false, "The ID is not correct");

            _event.SetDeleted();
            await dp.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<List<Event>> GetAllAsync()
    {
        return await dp.Events.Where(e => !e.IsDeleted).ToListAsync();
    }

    public async Task<Event?> GetIdAsync(int id)
    {
        return await dp.Events.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
    }

    public async Task<(bool, string?)> UpdateAsync(Event eventpram, int id)
    {
        try
        {
            var _event = await dp.Events.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            if (_event != null)
            {
                _event.UpdateEvent(eventpram.Name, eventpram.City, eventpram.Country, eventpram.EventDate, eventpram.Description);
                _event.SetModified();
                await dp.SaveChangesAsync();
                return (true, null);
            }

            return (false, "Event not found");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
