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

    // ✅ Create a new vendor
    public async Task<Vendor> CreateVendorAsync(Vendor vendor)
    {
      _context.Vendors.Add(vendor);
      await _context.SaveChangesAsync();
      return vendor;
    }

    // ✅ Update an existing vendor
    public async Task<Vendor> UpdateVendorAsync(int id, Vendor vendor)
    {
      var existingVendor = await _context.Vendors.FindAsync(id);
      if (existingVendor == null)
      {
        return null;
      }

      existingVendor.Name = vendor.Name;
      existingVendor.Website = vendor.Website;
      existingVendor.LoginWebsite = vendor.LoginWebsite;
      existingVendor.Phone = vendor.Phone;
      existingVendor.Consortium = vendor.Consortium;
      existingVendor.Description = vendor.Description;

      await _context.SaveChangesAsync();
      return existingVendor;
    }

    // ✅ Delete a vendor
    public async Task<Vendor> DeleteVendorAsync(int id)
    {
      var vendor = await _context.Vendors.FindAsync(id);
      if (vendor != null)
      {
        _context.Vendors.Remove(vendor);
        await _context.SaveChangesAsync();
        return vendor;
      }
      return null;
    }
  }
}
