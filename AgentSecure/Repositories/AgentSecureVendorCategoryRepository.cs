using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Repositories
{
  public class AgentSecureVendorCategoryRepository : IAgentSecureVendorCategoryRepository
  {
    // The repository layer is responsible for CRUD operations.
    // This repository class implements the IWeatherForecastRepository interface.
    // Remember: the interface is a contract that defines methods that a class MUST implement.
    // The repository layer will call the database context to do the actual CRUD operations.
    // The repository layer will return the data to the service layer.

    private readonly AgentSecureDbContext _context;

    public AgentSecureVendorCategoryRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // Seed data

    // Create VendorCategory

    public async Task<VendorCategory> CreateVendorCategoryAsync(VendorCategory vendorCategory)
    {
      _context.VendorCategories.Add(vendorCategory);
      await _context.SaveChangesAsync();
      return vendorCategory;
    }

    // Delete VendorCategory

    public async Task<VendorCategory> DeleteVendorCategoryAsync(int id)
    {
      var vendorCategory = await _context.VendorCategories.FindAsync(id);
      if (vendorCategory != null)
      {
        _context.VendorCategories.Remove(vendorCategory);
        await _context.SaveChangesAsync();
        return vendorCategory;
      }
      return null;
    }
  }
}
