using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Repositories;

namespace AgentSecure.Services
{
  public class AgentSecureVendorCategoryService : IAgentSecureVendorCategoryService
  {
    private readonly IAgentSecureVendorCategoryRepository _agentSecureVendorCategoryRepository;

    public AgentSecureVendorCategoryService(IAgentSecureVendorCategoryRepository agentSecureVendorCategoryRepository)
    {
      _agentSecureVendorCategoryRepository = agentSecureVendorCategoryRepository;
    }

    // Create VendorCategory
    public async Task<VendorCategory> CreateVendorCategoryAsync(VendorCategory vendorCategory)
    {
      return await _agentSecureVendorCategoryRepository.CreateVendorCategoryAsync(vendorCategory);
    }

    // Delete VendorCategory
    public async Task<VendorCategory> DeleteVendorCategoryAsync(int id)
    {
      return await _agentSecureVendorCategoryRepository.DeleteVendorCategoryAsync(id);
    }
  }
}
