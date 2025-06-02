#nullable enable
using Xunit;
using Moq;
using AgentSecure.Services;
using AgentSecure.Models;
using AgentSecure.Interfaces;
using AgentSecure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgentSecure.Tests
{
    public class UserTests
    {
        private readonly AgentSecureUserService _agentSecureUserService;
        private readonly Mock<IAgentSecureUserRepository> _mockUserRepository;

        public UserTests()
        {
            _mockUserRepository = new Mock<IAgentSecureUserRepository>();
            _agentSecureUserService = new AgentSecureUserService(_mockUserRepository.Object);
        }

        // Test for GetAllUsersAsync
        [Fact]
        public async Task GetAllUserAsync_ShouldReturnListOfUsers()
        {
            var expectedUsers = new List<UserProfileDto>
            {
                new UserProfileDto
                {
                    Id = 1,
                    FirstName = "User",
                    LastName = "One"
                },
                new UserProfileDto
                {
                    Id = 2,
                    FirstName = "User",
                    LastName = "Two"
                }
            };

            _mockUserRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(expectedUsers);

            // Act
            var actualUsers = await _agentSecureUserService.GetAllUsersAsync();

            // Assert
            _mockUserRepository.Verify(repo => repo.GetAllUsersAsync(), Times.Once);
            Assert.NotNull(actualUsers);
            Assert.Equal(expectedUsers.Count, actualUsers.Count);
            Assert.Equal(expectedUsers[0].FirstName, actualUsers[0].FirstName);
            Assert.Equal(expectedUsers[1].FirstName, actualUsers[1].FirstName);
            Assert.Equal(expectedUsers[0].LastName, actualUsers[0].LastName);
            Assert.Equal(expectedUsers[1].LastName, actualUsers[1].LastName);
        }

        // Test for GetUserByIdAsync

        [Fact]
        public async Task GetUserByIdAsync_ValidId_ShouldReturnUser()
        {
            // Arrange
            var expectedUser = new UserProfileDto
            {
                Id = 1,
                FirstName = "User",
                LastName = "One"
            };

            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(1)).ReturnsAsync(expectedUser);

            // Act
            var actualUser = await _agentSecureUserService.GetUserByIdAsync(1);

            // Assert
            _mockUserRepository.Verify(repo => repo.GetUserByIdAsync(1), Times.Once);
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
        }

        [Fact]
        public async Task GetUserByIdAsync_InvalidId_ShouldReturnNull()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(999)).ReturnsAsync((UserProfileDto?)null);

            // Act
            var actualUser = await _agentSecureUserService.GetUserByIdAsync(999);

            // Assert
            _mockUserRepository.Verify(repo => repo.GetUserByIdAsync(999), Times.Once);
            Assert.Null(actualUser);
        }

        // Tests for CreateUserAsync
        [Fact]
        public async Task CreateUserAsync_ValidId_ShouldReturnCreatedUser()
        {
            // Arrange
            var newUser = new User
            {
                Id = 3,
                FirstName = "User",
                LastName = "Three"
            };

            _mockUserRepository.Setup(repo => repo.CreateUserAsync(newUser)).ReturnsAsync(newUser);

            // Act
            var createdUser = await _agentSecureUserService.CreateUserAsync(newUser);

            // Assert
            _mockUserRepository.Verify(repo => repo.CreateUserAsync(newUser), Times.Once);
            Assert.NotNull(createdUser);
            Assert.Equal(newUser.Id, createdUser.Id);
            Assert.Equal(newUser.FirstName, createdUser.FirstName);
            Assert.Equal(newUser.LastName, createdUser.LastName);
        }

        [Fact]
        public async Task CreateUserAsync_InvalidId_ShouldReturnNull()
        {
            // Arrange
            var newUser = new User
            {
                Id = 999,
                FirstName = "Invalid",
                LastName = "User"
            };

            _mockUserRepository.Setup(repo => repo.CreateUserAsync(newUser)).ReturnsAsync((User?)null!);

            // Act
            var createdUser = await _agentSecureUserService.CreateUserAsync(newUser);

            // Assert
            _mockUserRepository.Verify(repo => repo.CreateUserAsync(newUser), Times.Once);
            Assert.Null(createdUser);
        }

        // Tests for UpdateUserAsync

        [Fact]
        public async Task UpdateUserAsync_ValidId_ShouldReturnUpdatedUser()
        {
            // Arrange
            var updatedUserDto = new UserProfileUpdateDto
            {
                Id = 1,
                FirstName = "Updated",
                LastName = "User"
            };

            var updatedUser = new User
            {
                Id = 1,
                FirstName = "Updated",
                LastName = "User"
            };

            _mockUserRepository.Setup(repo => repo.UpdateUserAsync(1, updatedUserDto)).ReturnsAsync(updatedUserDto);

            // Act
            var actualUser = await _agentSecureUserService.UpdateUserAsync(1, updatedUserDto);

            // Assert
            _mockUserRepository.Verify(repo => repo.UpdateUserAsync(1, updatedUserDto), Times.Once);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.FirstName, actualUser.FirstName);
        }

        [Fact]
        public async Task UpdateUserAsync_InvalidId_ShouldReturnNull()
        {
            // Arrange
            var updatedUserDto = new UserProfileUpdateDto
            {
                Id = 999,
                FirstName = "Invalid",
                LastName = "User"
            };

            _mockUserRepository.Setup(repo => repo.UpdateUserAsync(999, updatedUserDto)).ReturnsAsync((UserProfileUpdateDto?)null!);

            // Act
            var actualUser = await _agentSecureUserService.UpdateUserAsync(999, updatedUserDto);

            // Assert
            _mockUserRepository.Verify(repo => repo.UpdateUserAsync(999, updatedUserDto), Times.Once);
            Assert.Null(actualUser);
        }

        // Tests for DeleteUserAsync
        [Fact]
        public async Task DeleteUserAsync_ValidId_ShouldReturnDeletedUser()
        {
            // Arrange
            var deletedLogin = new User
            {
                Id = 1,
                FirstName = "Deleted",
                LastName = "User"
            };

            _mockUserRepository.Setup(repo => repo.DeleteUserAsync(1)).ReturnsAsync(deletedLogin);

            // Act
            var actualUser = await _agentSecureUserService.DeleteUserAsync(1);

            // Assert
            _mockUserRepository.Verify(repo => repo.DeleteUserAsync(1), Times.Once);
            Assert.NotNull(actualUser);
            Assert.Equal(deletedLogin.Id, actualUser.Id);
        }

        [Fact]
        public async Task DeleteUserAsync_InvalidId_ShouldReturnNull()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.DeleteUserAsync(999)).ReturnsAsync((User?)null!);

            // Act
            var actualUser = await _agentSecureUserService.DeleteUserAsync(999);

            // Assert
            _mockUserRepository.Verify(repo => repo.DeleteUserAsync(999), Times.Once);
            Assert.Null(actualUser);
        }
    }
}
