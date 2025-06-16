using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureUserService
  {
    Task<List<UserProfileDto>> GetAllUsersAsync();
    Task<UserProfileDto?> GetUserByIdAsync(int id);
    Task<User> CreateUserAsync(User user);
    Task<UserProfileUpdateDto> UpdateUserAsync(int id, UserProfileUpdateDto userProfileUpdateDto);
    Task<User> DeleteUserAsync(int id);
    Task<UserWithUidDto?> GetUserByFirebaseUidAsync(string firebaseUid);
  }
}
