using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Repositories
{
  public class AgentSecureCategoryRepository : IAgentSecureCategoryRepository
  {
    // The repository layer is responsible for CRUD operations.
    // This repository class implements the IWeatherForecastRepository interface.
    // Remember: the interface is a contract that defines methods that a class MUST implement.
    // The repository layer will call the database context to do the actual CRUD operations.
    // The repository layer will return the data to the service layer.

    private readonly AgentSecureDbContext _context;

    public AgentSecureCategoryRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // Get all categories
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
      return await _context.Categories
        .Include(c => c.VendorCategories)
          .ThenInclude(vc => vc.Vendor)
        .ToListAsync();
    }

    // Get a specific category by ID
    public async Task<Category> GetCategoryByIdAsync(int id)
    {
      return await _context.Categories
        .Include(c => c.VendorCategories)
          .ThenInclude(vc => vc.Vendor)
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    // Create a new category
    public async Task<Category> CreateCategoryAsync(Category category)
    {
      _context.Categories.Add(category);
      await _context.SaveChangesAsync();
      return category;
    }

    // Update an existing category
  }
}
