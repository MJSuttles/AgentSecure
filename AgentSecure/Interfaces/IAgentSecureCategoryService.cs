using AgentSecure.Models;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureCategoryService
  {
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(int id, Category category);
    Task<Category?> DeleteCategoryAsync(int id);
  }
}
