using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using System.Formats.Tar;

namespace AgentSecure.Repositories
{
  public class AgentSecureVendorRepository : IAgentSecureVendorRepository
  {
    // The repository layer is responsible for CRUD operations.
    // This repository class implements the IWeatherForecastRepository interface.
    // Remember: the interface is a contract that defines methods that a class MUST implement.
    // The repository layer will call the database context to do the actual CRUD operations.
    // The repository layer will return the data to the service layer.

    private readonly AgentSecureDbContext _context;

    public AgentSecureVendorRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // Seed data

    public async Task<List<Vendor>> GetAllVendorsAsync()
    {
      return await _context.Vendors
        .Include(v => v.Logins)
        .Include(v => v.VendorCategories)
          .ThenInclude(vt => vt.Category)
        .ToListAsync();
    }


  }
}
