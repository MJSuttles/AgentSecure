using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Repositories
{
  public class AgentSecureLoginRepository : IAgentSecureLoginRepository
  {
    // The repository layer is responsible for CRUD operations.
    // This repository class implements the IWeatherForecastRepository interface.
    // Remember: the interface is a contract that defines methods that a class MUST implement.
    // The repository layer will call the database context to do the actual CRUD operations.
    // The repository layer will return the data to the service layer.

    private readonly AgentSecureDbContext _context;

    public AgentSecureLoginRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // Seed data

    // Get all logins with related vendor and user info

    public async Task<List<LoginDto>> GetAllLoginsAsync()
    {
      return await _context.Logins
        .Select(l => new LoginDto
        {
          Username = l.Username,
          Email = l.Email,
          Password = l.Password,
          RegApproved = l.RegApproved,
          TrainingComplete = l.TrainingComplete
        })
        .ToListAsync();
    }

    // Get a specific login by ID with related vendor and user info

    public async Task<LoginDto> GetLoginByIdAsync(int id)
    {
      return await _context.Logins
        .Where(l => l.Id == id)
        .Select(l => new LoginDto
        {
          Username = l.Username,
          Email = l.Email,
          Password = l.Password,
          RegApproved = l.RegApproved,
          TrainingComplete = l.TrainingComplete
        })
        .FirstOrDefaultAsync();
    }

    // Create a new login

    public async Task<Login> CreateLoginAsync(Login login)
    {
      _context.Logins.Add(login);
      await _context.SaveChangesAsync();
      return login;
    }

    // Update an existing login

    public async Task<Login> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto)
    {
      var existingLogin = await _context.Logins.FindAsync(id);
      if (existingLogin == null)
      {
        return null;
      }

      existingLogin.Username = loginUpdateDto.Username;
      existingLogin.Email = loginUpdateDto.Email;
      existingLogin.Password = loginUpdateDto.Password;
      existingLogin.RegApproved = loginUpdateDto.RegApproved;
      existingLogin.TrainingComplete = loginUpdateDto.TrainingComplete;

      await _context.SaveChangesAsync();
      return existingLogin;
    }

    // Delete a login

    public async Task<Login> DeleteLoginAsync(int id)
    {
      var login = await _context.Logins.FindAsync(id);
      if (login != null)
      {
        _context.Logins.Remove(login);
        await _context.SaveChangesAsync();
        return login;
      }
      return null;
    }
  }
}
