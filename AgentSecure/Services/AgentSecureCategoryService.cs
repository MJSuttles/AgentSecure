using AgentSecure.Interfaces;
using AgentSecure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgentSecure.Services
{
  public class AgentSecureCategoryService : IAgentSecureCategoryService
  {
    private readonly IAgentSecureCategoryRepository _agentSecureCategoryRepository;

    public AgentSecureCategoryService(IAgentSecureCategoryRepository agentSecureCategoryRepository)
    {
      _agentSecureCategoryRepository = agentSecureCategoryRepository;
    }

    // Get all categories
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
      return await _agentSecureCategoryRepository.GetAllCategoriesAsync();
    }

    // Get a single category by id
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
      return await _agentSecureCategoryRepository.GetCategoryByIdAsync(id);
    }

    // Create a new category
    public async Task<Category> CreateCategoryAsync(Category category)
    {
      await _agentSecureCategoryRepository.CreateCategoryAsync(category);
      return category;
    }

    // Update a category
    public async Task<Category> UpdateCategoryAsync(int id, Category category)
    {
      return await _agentSecureCategoryRepository.UpdateCategoryAsync(id, category);
    }

    // Delete a category
    public async Task<Category> DeleteCategoryAsync(int id)
    {
      return await _agentSecureCategoryRepository.DeleteCategoryAsync(id);
    }
  }
}
