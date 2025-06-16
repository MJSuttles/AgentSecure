using AgentSecure.Models;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureVendorCategoryRepository
  {
    Task<VendorCategory> CreateVendorCategoryAsync(VendorCategory vendorCategory);
    Task<VendorCategory> DeleteVendorCategoryAsync(int id);
  }
}
