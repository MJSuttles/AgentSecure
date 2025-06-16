using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureLoginService
  {
    Task<List<LoginDto>> GetAllLoginsAsync();
    Task<List<LoginDto>> GetLoginsByUserIdAsync(int userId);
    Task<LoginDto?> GetLoginByIdAsync(int id);
    Task<LoginDto> CreateLoginAsync(Login login);
    Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto);
    Task<Login?> DeleteLoginAsync(int id);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
    Task<string?> RevealPasswordByLoginIdAsync(int loginId);
  }
}
