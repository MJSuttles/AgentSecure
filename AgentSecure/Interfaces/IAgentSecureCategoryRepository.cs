using AgentSecure.Models;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureCategoryRepository
  {
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(int id, Category category);
    Task<Category?> DeleteCategoryAsync(int id);
  }
}
