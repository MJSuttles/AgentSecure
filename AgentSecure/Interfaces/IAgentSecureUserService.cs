using AgentSecure.Models;
using AgentSecure.DTOs;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureUserService
  {
    // An interface is a contract that defines the signature of the functionality.
    // It defines a set of methods that a class that inherits the interface MUST implement.
    // The interface is a mechanism to achieve abstraction.
    // Interfaces can be used in unit testing to mock out the actual implementation.

    // seed categories

    Task<List<UserProfileDto>> GetAllUsersAsync();
    Task<UserProfileDto?> GetUserByIdAsync(int id);
    Task<User> CreateUserAsync(User user);
    Task<UserProfileUpdateDto> UpdateUserAsync(int id, UserProfileUpdateDto userProfileUpdateDto);
    Task<User> DeleteUserAsync(int id);
    Task<UserWithUidDto?> GetUserByFirebaseUidAsync(string firebaseUid);
  }
}
