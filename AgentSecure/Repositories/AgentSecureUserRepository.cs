using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using System.Reflection.Metadata.Ecma335;

namespace AgentSecure.Repositories
{
  public class AgentSecureUserRepository : IAgentSecureUserRepository
  {
    // The repository layer is responsible for CRUD operations.
    // This repository class implements the IWeatherForecastRepository interface.
    // Remember: the interface is a contract that defines methods that a class MUST implement.
    // The repository layer will call the database context to do the actual CRUD operations.
    // The repository layer will return the data to the service layer.

    private readonly AgentSecureDbContext _context;

    public AgentSecureUserRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // Seed data

    public async Task<List<User>> GetAllUsersAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<User> UpdateUserAsync(int id, User user)
    {
      var existingUser = await _context.Users.FindAsync(id);
      if (existingUser == null)
      {
        return null;
      }
      existingUser.FirstName = user.FirstName;
      existingUser.LastName = user.LastName;
      existingUser.Email = user.Email;
      existingUser.Phone = user.Phone;
      existingUser.StreetAddress = user.StreetAddress;
      existingUser.City = user.City;
      existingUser.State = user.State;
      existingUser.Zip = user.Zip;

      await _context.SaveChangesAsync();
      return existingUser;
    }

    public async Task<User> DeleteUserAsync(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user != null)
      {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
      }
      return null;
    }
  }
}
