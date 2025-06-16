using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;
using AgentSecure.Helpers;

namespace AgentSecure.Services
{
  public class AgentSecureLoginService : IAgentSecureLoginService
  {
    private readonly IAgentSecureLoginRepository _agentSecureLoginRepository;
    private readonly IAgentSecureUserRepository _agentSecureUserRepository;
    private readonly IAgentSecureVendorRepository _agentSecureVendorRepository;

    public AgentSecureLoginService(
      IAgentSecureLoginRepository agentSecureLoginRepository,
      IAgentSecureUserRepository agentSecureUserRepository,
      IAgentSecureVendorRepository agentSecureVendorRepository)
    {
      _agentSecureLoginRepository = agentSecureLoginRepository;
      _agentSecureUserRepository = agentSecureUserRepository;
      _agentSecureVendorRepository = agentSecureVendorRepository;
    }

    // Get All Logins

    public async Task<List<LoginDto>> GetAllLoginsAsync()
    {
      return await _agentSecureLoginRepository.GetAllLoginsAsync();
    }

    // Get Logins by User Id

    public async Task<List<LoginDto>> GetLoginsByUserIdAsync(int userId)
    {
      return await _agentSecureLoginRepository.GetLoginsByUserIdAsync(userId);
    }

    // Get Login by Id

    public async Task<LoginDto?> GetLoginByIdAsync(int id)
    {
      return await _agentSecureLoginRepository.GetLoginByIdAsync(id);
    }

    // Create Login

    public async Task<LoginDto> CreateLoginAsync(Login loginPayload)
    {
      if (loginPayload?.User?.Uid == null)
      {
        throw new ArgumentException("Firebase UID is missing in payload.");
      }

      var user = await _agentSecureUserRepository.GetUserByFirebaseUidAsync(loginPayload.User.Uid);
      if (user == null)
      {
        throw new Exception($"No user found for UID: {loginPayload.User.Uid}");
      }

      var vendor = await _agentSecureVendorRepository.GetVendorByIdAsync(loginPayload.VendorId);
      if (vendor == null)
      {
        throw new Exception($"No vendor found with ID: {loginPayload.VendorId}");
      }

      // Encrypt password before saving
      string encryptedPassword = EncryptionHelper.Encrypt(loginPayload.Password);

      var newLogin = new Login
      {
        UserId = user.Id,
        VendorId = loginPayload.VendorId,
        Username = loginPayload.Username,
        Email = loginPayload.Email,
        Password = encryptedPassword,
        RegApproved = loginPayload.RegApproved,
        TrainingComplete = loginPayload.TrainingComplete
      };

      var createdLogin = await _agentSecureLoginRepository.CreateLoginAsync(newLogin);

      // Return decrypted version for frontend use
      return new LoginDto
      {
        Id = createdLogin.Id,
        VendorName = vendor.Name,
        Username = createdLogin.Username,
        Email = createdLogin.Email,
        Password = loginPayload.Password, // Decrypted
        RegApproved = createdLogin.RegApproved,
        TrainingComplete = createdLogin.TrainingComplete
      };
    }

    // Update Login

    public async Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto)
    {
      return await _agentSecureLoginRepository.UpdateLoginAsync(id, loginUpdateDto);
    }

    // Delete Login

    public async Task<Login?> DeleteLoginAsync(int id)
    {
      return await _agentSecureLoginRepository.DeleteLoginAsync(id);
    }

    // Change Password

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
      return await _agentSecureLoginRepository.ChangePasswordAsync(dto);
    }

    // Reveal Password

    public async Task<string?> RevealPasswordByLoginIdAsync(int loginId)
    {
      return await _agentSecureLoginRepository.RevealPasswordByLoginIdAsync(loginId);
    }
  }
}
