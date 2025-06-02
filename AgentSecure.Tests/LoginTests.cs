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
  public class LoginTests
  {
    private readonly AgentSecureLoginService _agentSecureLoginService;
    private readonly Mock<IAgentSecureLoginRepository> _mockLoginRepository;

    public LoginTests()
    {
      _mockLoginRepository = new Mock<IAgentSecureLoginRepository>();
      _agentSecureLoginService = new AgentSecureLoginService(_mockLoginRepository.Object);
    }

    // Test for GetAllLoginsAsync

    [Fact]
    public async Task GetAllLoginsAsync_ShouldReturnListOfLogins()
    {
      // Arrange
      var expectedLogins = new List<LoginDto>
      {
        new LoginDto
        {
          Id = 1,
          Username = "user1",
          Password = "password1"
        },
        new LoginDto
        {
          Id = 2,
          Username = "user2",
          Password = "password2"
        }
      };

      _mockLoginRepository.Setup(repo => repo.GetAllLoginsAsync()).ReturnsAsync(expectedLogins);

      // Act
      var actualLogins = await _agentSecureLoginService.GetAllLoginsAsync();

      // Assert
      _mockLoginRepository.Verify(repo => repo.GetAllLoginsAsync(), Times.Once);
      Assert.Equal(expectedLogins.Count, actualLogins.Count);
      Assert.Equal(expectedLogins[0].Username, actualLogins[0].Username);
      Assert.Equal(expectedLogins[1].Username, actualLogins[1].Username);
    }

    // Tests for GetLoginByIdAsync

    [Fact]
    public async Task GetLoginByIdAsync_ValidId_ShouldReturnLogin()
    {
      // Arrange
      var expectedLogin = new LoginDto
      {
        Id = 1,
        Username = "user1",
        Password = "password1"
      };

      _mockLoginRepository.Setup(repo => repo.GetLoginByIdAsync(1)).ReturnsAsync(expectedLogin);

      // Act
      var actualLogin = await _agentSecureLoginService.GetLoginByIdAsync(1);

      // Assert
      _mockLoginRepository.Verify(repo => repo.GetLoginByIdAsync(1), Times.Once);
      Assert.NotNull(actualLogin);
      Assert.Equal(expectedLogin.Username, actualLogin.Username);
    }

    [Fact]
    public async Task GetLoginByIdAsync_InvalidId_ShouldReturnNull()
    {
      // Arrange
      _mockLoginRepository.Setup(repo => repo.GetLoginByIdAsync(999)).ReturnsAsync((LoginDto?)null);

      // Act
      var actualLogin = await _agentSecureLoginService.GetLoginByIdAsync(999);

      // Assert
      _mockLoginRepository.Verify(repo => repo.GetLoginByIdAsync(999), Times.Once);
      Assert.Null(actualLogin);
    }

    // Tests for CreateLoginAsync

    [Fact]
    public async Task CreateLoginAsync_ValidLogin_ShouldReturnCreatedLogin()
    {
      // Arrange
      var newLogin = new Login
      {
        Username = "newuser",
        Password = "newpassword"
      };

      var createdLogin = new Login
      {
        Id = 1,
        Username = "newuser",
        Password = "newpassword"
      };

      _mockLoginRepository.Setup(repo => repo.CreateLoginAsync(newLogin)).ReturnsAsync(createdLogin);

      // Act
      var actualLogin = await _agentSecureLoginService.CreateLoginAsync(newLogin);

      // Assert
      _mockLoginRepository.Verify(repo => repo.CreateLoginAsync(newLogin), Times.Once);
      Assert.NotNull(actualLogin);
      Assert.Equal(createdLogin.Username, actualLogin.Username);
    }

    [Fact]
    public async Task CreateLoginAsync_InvalidLogin_ShouldReturnNull()
    {
      // Arrange
      var newLogin = new Login
      {
        Username = "invaliduser",
        Password = "invalidpassword"
      };

      _mockLoginRepository.Setup(repo => repo.CreateLoginAsync(newLogin)).ReturnsAsync((Login?)null!);

      // Act
      var actualLogin = await _agentSecureLoginService.CreateLoginAsync(newLogin);

      // Assert
      _mockLoginRepository.Verify(repo => repo.CreateLoginAsync(newLogin), Times.Once);
      Assert.Null(actualLogin);
    }

    // Tests for UpdateLoginAsync

    [Fact]
    public async Task UpdateLoginAsync_ValidId_ShouldReturnUpdatedLogin()
    {
      // Arrange
      var updatedLoginDto = new LoginUpdateDto
      {
        Id = 1,
        Username = "updateduser",
        Password = "updatedpassword"
      };

      var updatedLogin = new Login
      {
        Id = 1,
        Username = "updateduser",
        Password = "updatedpassword"
      };

      _mockLoginRepository.Setup(repo => repo.UpdateLoginAsync(1, updatedLoginDto)).ReturnsAsync(updatedLoginDto);

      // Act
      var actualLogin = await _agentSecureLoginService.UpdateLoginAsync(1, updatedLoginDto);

      // Assert
      _mockLoginRepository.Verify(repo => repo.UpdateLoginAsync(1, updatedLoginDto), Times.Once);
      Assert.NotNull(actualLogin);
      Assert.Equal(updatedLogin.Username, actualLogin.Username);
    }

    [Fact]
    public async Task UpdateLoginAsync_InvalidId_ShouldReturnNull()
    {
      // Arrange
      var updatedLoginDto = new LoginUpdateDto
      {
        Id = 999,
        Username = "updateduser",
        Password = "updatedpassword"
      };

      _mockLoginRepository.Setup(repo => repo.UpdateLoginAsync(999, updatedLoginDto)).ReturnsAsync((LoginUpdateDto?)null!);

      // Act
      var actualLogin = await _agentSecureLoginService.UpdateLoginAsync(999, updatedLoginDto);

      // Assert
      _mockLoginRepository.Verify(repo => repo.UpdateLoginAsync(999, updatedLoginDto), Times.Once);
      Assert.Null(actualLogin);
    }

    // Tests for DeleteLoginAsync
    [Fact]
    public async Task DeleteLoginAsync_ValidId_ShouldReturnDeletedLogin()
    {
      // Arrange

      var deletedLogin = new Login
      {
        Id = 1,
        Username = "user1",
        Password = "password1"
      };

      _mockLoginRepository.Setup(repo => repo.DeleteLoginAsync(1)).ReturnsAsync(deletedLogin);

      // Act
      var actualLogin = await _agentSecureLoginService.DeleteLoginAsync(1);

      // Assert
      _mockLoginRepository.Verify(repo => repo.DeleteLoginAsync(1), Times.Once);
      Assert.NotNull(actualLogin);
      Assert.Equal(deletedLogin.Username, actualLogin.Username);
    }

    [Fact]
    public async Task DeleteLoginAsync_InvalidId_ShouldReturnNull()
    {
      // Arrange
      _mockLoginRepository.Setup(repo => repo.DeleteLoginAsync(999)).ReturnsAsync((Login?)null);

      // Act
      var actualLogin = await _agentSecureLoginService.DeleteLoginAsync(999);

      // Assert
      _mockLoginRepository.Verify(repo => repo.DeleteLoginAsync(999), Times.Once);
      Assert.Null(actualLogin);
    }

  }
}
