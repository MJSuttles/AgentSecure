using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;

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
    public async Task<List<VendorDto>> GetAllVendorsAsync()
    {
      return await _context.Vendors
        .Include(v => v.VendorCategories)
          .ThenInclude(vc => vc.Category)
        .Select(v => new VendorDto
        {
          Name = v.Name,
          Website = v.Website,
          LoginWebsite = v.LoginWebsite,
          Phone = v.Phone,
          Consortium = v.Consortium,
          Description = v.Description,
          Categories = v.VendorCategories
            .Where(vc => vc.Category != null)
            .Select(vc => vc.Category.CatName)
            .ToList()
        })
        .ToListAsync();
    }

    // ✅ Get a specific vendor by ID with related logins and category info
    public async Task<VendorDto?> GetVendorByIdAsync(int id)
    {
      return await _context.Vendors
        .Include(v => v.VendorCategories)
          .ThenInclude(vc => vc.Category)
        .Where(v => v.Id == id)
        .Select(v => new VendorDto
        {
          Name = v.Name,
          Website = v.Website,
          LoginWebsite = v.LoginWebsite,
          Phone = v.Phone,
          Consortium = v.Consortium,
          Description = v.Description,
          Categories = v.VendorCategories
            .Where(vc => vc.Category != null)
            .Select(vc => vc.Category.CatName)
            .ToList()
        })
        .FirstOrDefaultAsync();
    }

    // ✅ Create a new vendor
    public async Task<Vendor> CreateVendorAsync(Vendor vendor)
    {
      _context.Vendors.Add(vendor);
      await _context.SaveChangesAsync();
      return vendor;
    }

    // ✅ Update an existing vendor
    public async Task<VendorUpdateDto> UpdateVendorAsync(int id, VendorUpdateDto vendorUpdateDto)
    {
      var existingVendor = await _context.Vendors
        .Include(v => v.VendorCategories)
          .ThenInclude(vc => vc.Category)
        .FirstOrDefaultAsync(v => v.Id == id);

      if (existingVendor == null) return null;

      // Update basic vendor fields
      existingVendor.Name = vendorUpdateDto.Name;
      existingVendor.Website = vendorUpdateDto.Website;
      existingVendor.LoginWebsite = vendorUpdateDto.LoginWebsite;
      existingVendor.Phone = vendorUpdateDto.Phone;
      existingVendor.Consortium = vendorUpdateDto.Consortium;
      existingVendor.Description = vendorUpdateDto.Description;

      // Remove existing VendorCategory relationships
      var oldVendorCategories = _context.VendorCategories.Where(vc => vc.VendorId == id);
      _context.VendorCategories.RemoveRange(oldVendorCategories);

      // Get updated categories by name
      var categoryEntities = await _context.Categories
        .Where(c => vendorUpdateDto.Categories.Contains(c.CatName))
        .ToListAsync();

      // Add new VendorCategory relationships
      existingVendor.VendorCategories = categoryEntities
        .Select(c => new VendorCategory { VendorId = id, CategoryId = c.Id })
        .ToList();

      await _context.SaveChangesAsync();

      // Re-fetch to ensure navigation properties are populated
      var refreshedVendor = await _context.Vendors
        .Include(v => v.VendorCategories)
          .ThenInclude(vc => vc.Category)
        .FirstOrDefaultAsync(v => v.Id == id);

      // Return updated VendorUpdateDto
      return new VendorUpdateDto
      {
        Name = refreshedVendor.Name,
        Website = refreshedVendor.Website,
        LoginWebsite = refreshedVendor.LoginWebsite,
        Phone = refreshedVendor.Phone,
        Consortium = refreshedVendor.Consortium,
        Description = refreshedVendor.Description,
        Categories = refreshedVendor.VendorCategories
          .Where(vc => vc.Category != null)
          .Select(vc => vc.Category.CatName)
          .ToList()
      };
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
