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
          Id = u.Id,
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
          Id = u.Id,
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

    public async Task<UserProfileUpdateDto> UpdateUserAsync(int id, UserProfileUpdateDto userProfileUpdateDto)
    {
      var existingUser = await _context.Users.FindAsync(id);
      if (existingUser == null)
      {
        return null;
      }

      // Never change the primary key
      existingUser.FirstName = userProfileUpdateDto.FirstName;
      existingUser.LastName = userProfileUpdateDto.LastName;
      existingUser.Email = userProfileUpdateDto.Email;
      existingUser.Phone = userProfileUpdateDto.Phone;
      existingUser.StreetAddress = userProfileUpdateDto.StreetAddress;
      existingUser.City = userProfileUpdateDto.City;
      existingUser.State = userProfileUpdateDto.State;
      existingUser.Zip = userProfileUpdateDto.Zip;

      await _context.SaveChangesAsync();

      return new UserProfileUpdateDto
      {
        Id = existingUser.Id,
        FirstName = existingUser.FirstName,
        LastName = existingUser.LastName,
        Email = existingUser.Email,
        Phone = existingUser.Phone,
        StreetAddress = existingUser.StreetAddress,
        City = existingUser.City,
        State = existingUser.State,
        Zip = existingUser.Zip
      };
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

    public async Task<User?> GetUserByFirebaseUidAsync(string firebaseUid)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Uid == firebaseUid);
    }
  }
}
