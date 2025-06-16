using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureLoginRepository
  {
    Task<List<LoginDto>> GetAllLoginsAsync();
    Task<List<LoginDto>> GetLoginsByUserIdAsync(int userId);
    Task<LoginDto?> GetLoginByIdAsync(int id);
    Task<Login> CreateLoginAsync(Login login);
    Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto);
    Task<Login?> DeleteLoginAsync(int id);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
    Task<Login?> GetLoginByIdRawAsync(int id);
    Task<string?> RevealPasswordByLoginIdAsync(int loginId);

  }
}
