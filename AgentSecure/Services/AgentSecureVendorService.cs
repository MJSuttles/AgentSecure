using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Repositories;
using AgentSecure.DTOs;

namespace AgentSecure.Services
{
  public class AgentSecureVendorService : IAgentSecureVendorService
  {
    private readonly IAgentSecureVendorRepository _agentSecureVendorRepository;
    public AgentSecureVendorService(IAgentSecureVendorRepository agentSecureVendorRepository)
    {
      _agentSecureVendorRepository = agentSecureVendorRepository;
    }

    // Get All Vendors

    public async Task<List<VendorDto>> GetAllVendorsAsync()
    {
      return await _agentSecureVendorRepository.GetAllVendorsAsync();
    }

    // Get Vendor By Id

    public async Task<VendorDto?> GetVendorByIdAsync(int id)
    {
      return await _agentSecureVendorRepository.GetVendorByIdAsync(id);
    }

    // Create Vendor

    public async Task<Vendor> CreateVendorAsync(Vendor vendor)
    {
      return await _agentSecureVendorRepository.CreateVendorAsync(vendor);
    }

    // Update Vendor

    public async Task<VendorUpdateDto> UpdateVendorAsync(int id, VendorUpdateDto vendorUpdateDto)
    {
      return await _agentSecureVendorRepository.UpdateVendorAsync(id, vendorUpdateDto);
    }

    // Delete Vendor

    public async Task<Vendor?> DeleteVendorAsync(int id)
    {
      return await _agentSecureVendorRepository.DeleteVendorAsync(id);
    }
  }
}
