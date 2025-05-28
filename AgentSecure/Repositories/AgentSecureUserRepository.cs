using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Repositories
{
  public class AgentSecureUserRepository : IAgentSecureUserRepository
  {
    private readonly AgentSecureDbContext _context;

    public AgentSecureUserRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    public async Task<List<UserProfileDto>> GetAllUsersAsync()
    {
      return await _context.Users
        .Select(u => new UserProfileDto
        {
          FirstName = u.FirstName,
          LastName = u.LastName,
          Email = u.Email,
          Phone = u.Phone,
          StreetAddress = u.StreetAddress,
          City = u.City,
          State = u.State,
          Zip = u.Zip
        })
        .ToListAsync();
    }

    public async Task<UserProfileDto?> GetUserByIdAsync(int id)
    {
      return await _context.Users
        .Where(u => u.Id == id)
        .Select(u => new UserProfileDto
        {
          FirstName = u.FirstName,
          LastName = u.LastName,
          Email = u.Email,
          Phone = u.Phone,
          StreetAddress = u.StreetAddress,
          City = u.City,
          State = u.State,
          Zip = u.Zip
        })
        .FirstOrDefaultAsync();
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
