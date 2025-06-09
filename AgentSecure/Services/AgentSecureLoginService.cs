using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Services
{
  public class AgentSecureLoginService : IAgentSecureLoginService
  {
    private readonly IAgentSecureLoginRepository _agentSecureLoginRepository;
    private readonly IAgentSecureUserRepository _agentSecureUserRepository;

    public AgentSecureLoginService(
      IAgentSecureLoginRepository agentSecureLoginRepository,
      IAgentSecureUserRepository agentSecureUserRepository)
    {
      _agentSecureLoginRepository = agentSecureLoginRepository;
      _agentSecureUserRepository = agentSecureUserRepository;
    }

    public async Task<List<LoginDto>> GetAllLoginsAsync()
    {
      return await _agentSecureLoginRepository.GetAllLoginsAsync();
    }

    public async Task<List<LoginDto>> GetLoginsByUserIdAsync(int userId)
    {
      return await _agentSecureLoginRepository.GetLoginsByUserIdAsync(userId);
    }

    public async Task<LoginDto?> GetLoginByIdAsync(int id)
    {
      return await _agentSecureLoginRepository.GetLoginByIdAsync(id);
    }

    public async Task<Login> CreateLoginAsync(Login loginPayload)
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

      var newLogin = new Login
      {
        UserId = user.Id,
        VendorId = loginPayload.VendorId,
        Username = loginPayload.Username,
        Email = loginPayload.Email,
        Password = loginPayload.Password,
        RegApproved = loginPayload.RegApproved,
        TrainingComplete = loginPayload.TrainingComplete
      };

      return await _agentSecureLoginRepository.CreateLoginAsync(newLogin);
    }

    public async Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto)
    {
      return await _agentSecureLoginRepository.UpdateLoginAsync(id, loginUpdateDto);
    }

    public async Task<Login?> DeleteLoginAsync(int id)
    {
      return await _agentSecureLoginRepository.DeleteLoginAsync(id);
    }
  }
}
