using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;

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

    public async Task<List<Login>> GetAllLoginsAsync()
    {
      return await _context.Logins
        .Include(l => l.User)
        .Include(l => l.Vendor)
          .ThenInclude(v => v.VendorCategories)
            .ThenInclude(vc => vc.Category)
            .ToListAsync();
    }

    // Get a specific login by ID with related vendor and user info

    public async Task<Login?> GetLoginByIdAsync(int id)
    {
      return await _context.Logins
        .Include(l => l.User)
        .Include(l => l.Vendor)
          .ThenInclude(v => v.VendorCategories)
            .ThenInclude(vc => vc.Category)
        .FirstOrDefaultAsync(l => l.Id == id);
    }

    // Create a new login

    public async Task<Login> CreateLoginAsync(Login login)
    {
      _context.Logins.Add(login);
      await _context.SaveChangesAsync();
      return login;
    }

    // Update an existing login

    public async Task<Login> UpdateLoginAsync(int id, Login login)
    {
      var existingLogin = await _context.Logins.FindAsync(id);
      if (existingLogin == null)
      {
        return null;
      }

      existingLogin.Username = login.Username;
      existingLogin.Email = login.Email;
      existingLogin.Password = login.Password;
      existingLogin.RegApproved = login.RegApproved;
      existingLogin.TrainingComplete = login.TrainingComplete;

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
