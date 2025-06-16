using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureVendorService
  {
    Task<List<VendorDto>> GetAllVendorsAsync();
    Task<VendorDto?> GetVendorByIdAsync(int id);
    Task<Vendor> CreateVendorAsync(Vendor vendor);
    Task<VendorUpdateDto> UpdateVendorAsync(int id, VendorUpdateDto vendorUpdateDto);
    Task<Vendor?> DeleteVendorAsync(int id);
  }
}
