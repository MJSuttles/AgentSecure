using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureLoginRepository
  {
    // An interface is a contract that defines the signature of the functionality.
    // It defines a set of methods that a class that inherits the interface MUST implement.
    // The interface is a mechanism to achieve abstraction.
    // Interfaces can be used in unit testing to mock out the actual implementation.

    // seed categories
    Task<List<LoginDto>> GetAllLoginsAsync();
    Task<List<LoginDto>> GetLoginsByUserIdAsync(int userId);
    Task<LoginDto?> GetLoginByIdAsync(int id);
    Task<Login> CreateLoginAsync(Login login);
    Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto);
    Task<Login?> DeleteLoginAsync(int id);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
    Task<string?> RevealPasswordByLoginIdAsync(int loginId);

  }
}
