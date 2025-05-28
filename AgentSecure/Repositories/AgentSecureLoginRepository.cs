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


  }
}
