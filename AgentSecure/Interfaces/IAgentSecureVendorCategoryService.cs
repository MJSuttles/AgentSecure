using AgentSecure.Models;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureVendorCategoryService
  {
    Task<VendorCategory> CreateVendorCategoryAsync(VendorCategory vendorCategory);
    Task<VendorCategory> DeleteVendorCategoryAsync(int id);
  }
}
