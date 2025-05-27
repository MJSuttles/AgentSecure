using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Repositories
{
  public class AgentSecureCategoryRepository : IAgentSecureCategoryRepository
  {
    private readonly AgentSecureDbContext _context;

    public AgentSecureCategoryRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // ✅ Get all categories with related vendors
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
      return await _context.Categories
        .Include(c => c.VendorCategories)
          .ThenInclude(vc => vc.Vendor)
        .ToListAsync();
    }

    // ✅ Get a category by ID
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
      return await _context.Categories
        .Include(c => c.VendorCategories)
          .ThenInclude(vc => vc.Vendor)
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    // ✅ Create a new category
    public async Task<Category> CreateCategoryAsync(Category category)
    {
      _context.Categories.Add(category);
      await _context.SaveChangesAsync();
      return category;
    }

    // ✅ Update an existing category
    public async Task<Category> UpdateCategoryAsync(int id, Category category)
    {
      var existingCategory = await _context.Categories.FindAsync(id);
      if (existingCategory == null)
      {
        return null;
      }

      existingCategory.CatName = category.CatName;
      await _context.SaveChangesAsync();
      return existingCategory;
    }

    // ✅ Delete a category
    public async Task<Category> DeleteCategoryAsync(int id)
    {
      var existingCategory = await _context.Categories.FindAsync(id);
      if (existingCategory != null)
      {
        _context.Categories.Remove(existingCategory);
        await _context.SaveChangesAsync();
        return existingCategory;
      }
      return null;
    }
  }
}
