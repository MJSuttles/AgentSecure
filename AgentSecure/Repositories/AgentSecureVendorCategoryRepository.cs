using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Repositories
{
  public class AgentSecureVendorCategoryRepository : IAgentSecureVendorCategoryRepository
  {
    private readonly AgentSecureDbContext _context;

    public AgentSecureVendorCategoryRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

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
