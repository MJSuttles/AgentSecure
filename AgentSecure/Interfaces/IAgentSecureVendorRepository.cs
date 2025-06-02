using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureVendorRepository
  {
    // An interface is a contract that defines the signature of the functionality.
    // It defines a set of methods that a class that inherits the interface MUST implement.
    // The interface is a mechanism to achieve abstraction.
    // Interfaces can be used in unit testing to mock out the actual implementation.

    // seed categories

    Task<List<VendorDto>> GetAllVendorsAsync();
    Task<VendorDto?> GetVendorByIdAsync(int id);
    Task<Vendor> CreateVendorAsync(Vendor vendor);
    Task<VendorUpdateDto> UpdateVendorAsync(int id, VendorUpdateDto vendorUpdateDto);
    Task<Vendor?> DeleteVendorAsync(int id);
  }
}
