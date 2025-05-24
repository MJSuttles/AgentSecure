using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Repositories
{
  public class AgentSecureVendorRepository : IAgentSecureVendorRepository
  {
    // The repository layer is responsible for CRUD operations.
    // This class implements IAgentSecureVendorRepository and uses the injected DbContext
    private readonly AgentSecureDbContext _context;

    public AgentSecureVendorRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // ✅ Get all vendors with related logins and category info
    public async Task<List<Vendor>> GetAllVendorsAsync()
    {
      return await _context.Vendors
        .Include(v => v.Logins)
        .Include(v => v.VendorCategories)
          .ThenInclude(vc => vc.Category)
        .ToListAsync();
    }

    // ✅ Get a specific vendor by ID with related logins and category info
    public async Task<Vendor?> GetVendorByIdAsync(int id)
    {
      return await _context.Vendors
        .Include(v => v.Logins)
        .Include(v => v.VendorCategories)
          .ThenInclude(vc => vc.Category)
        .FirstOrDefaultAsync(v => v.Id == id);
    }
  }
}
