using System.Security.Cryptography.X509Certificates;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Repositories;
using AgentSecure.DTOs;

namespace AgentSecure.Services
{
  public class AgentSecureUserService : IAgentSecureUserService
  {
    // The service layer is responsible for processing business logic.
    // Right now, the service layer is just calling the repository layer.
    // The service layer will call the repository layer to do the actual CRUD operations.
    // The service layer will return the data to the endpoint (controller).

    private readonly IAgentSecureUserRepository _agentSecureUserRepository;
    public AgentSecureUserService(IAgentSecureUserRepository agentSecureUserRepository)
    {
      _agentSecureUserRepository = agentSecureUserRepository;
    }

    // Get All Users

    public async Task<List<UserProfileDto>> GetAllUsersAsync()
    {
      return await _agentSecureUserRepository.GetAllUsersAsync();
    }

    // Get User by Id

    public async Task<UserProfileDto?> GetUserByIdAsync(int id)
    {
      return await _agentSecureUserRepository.GetUserByIdAsync(id);
    }

    // Create User

    public async Task<User> CreateUserAsync(User user)
    {
      return await _agentSecureUserRepository.CreateUserAsync(user);
    }

    // Update User

    public async Task<UserProfileUpdateDto> UpdateUserAsync(int id, UserProfileUpdateDto userProfileUpdateDto)
    {
      return await _agentSecureUserRepository.UpdateUserAsync(id, userProfileUpdateDto);
    }

    // Delete User

    public async Task<User> DeleteUserAsync(int id)
    {
      return await _agentSecureUserRepository.DeleteUserAsync(id);
    }

    // Get User by Firebase Id

    public async Task<UserWithUidDto?> GetUserByFirebaseUidAsync(string firebaseUid)
    {
      return await _agentSecureUserRepository.GetUserByFirebaseUidAsync(firebaseUid);
    }
  }
}
