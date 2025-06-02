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
  public class VendorCategoryTests
  {
    private readonly AgentSecureVendorCategoryService _agentSecureVendorCategoryService;
    private readonly Mock<IAgentSecureVendorCategoryRepository> _mockVendorCategoryRepository;

    public VendorCategoryTests()
    {
      _mockVendorCategoryRepository = new Mock<IAgentSecureVendorCategoryRepository>();
      _agentSecureVendorCategoryService = new AgentSecureVendorCategoryService(_mockVendorCategoryRepository.Object);
    }

    [Fact]
    public async Task CreateVendorCategoryAsync_ValidId_ShouldCreateVendorCategory()
    {
      // Arrange
      var newVendorCategory = new VendorCategory
      {
        Id = 1,
        VendorId = 1,
        CategoryId = 1
      };

      var createdVendorCategory = new VendorCategory
      {
        Id = 1,
        VendorId = 1,
        CategoryId = 1
      };

      _mockVendorCategoryRepository
        .Setup(repo => repo.CreateVendorCategoryAsync(newVendorCategory))
        .ReturnsAsync(createdVendorCategory);

      // Act
      var actualLogin = await _agentSecureVendorCategoryService.CreateVendorCategoryAsync(newVendorCategory);

      // Assert
      _mockVendorCategoryRepository.Verify(repo => repo.CreateVendorCategoryAsync(newVendorCategory), Times.Once);
      Assert.NotNull(actualLogin);
    }

    [Fact]
    public async Task CreateVendorCategoryAsync_InvalidId_ShoudReturnNull()
    {
      // Arrange
      var newVendorCategory = new VendorCategory
      {
        Id = 999,
        VendorId = 1,
      };

      _mockVendorCategoryRepository.Setup(repo => repo.CreateVendorCategoryAsync(newVendorCategory)).ReturnsAsync((VendorCategory?)null!);

      // Act
      var actualVendorCategory = await _agentSecureVendorCategoryService.CreateVendorCategoryAsync(newVendorCategory);

      // Assert
      _mockVendorCategoryRepository.Verify(repo => repo.CreateVendorCategoryAsync(newVendorCategory), Times.Once);
      Assert.Null(actualVendorCategory);
    }

    // Tests for DeleteVendorCategoryAsync

    [Fact]
    public async Task DeleteVendorCategoryAsync_ValidId_ShouldReturnDeletedVendorCategory()
    {
      // Arrange
      var vendorCategory = new VendorCategory
      {
        Id = 1,
        VendorId = 1,
        CategoryId = 1
      };

      _mockVendorCategoryRepository
        .Setup(repo => repo.DeleteVendorCategoryAsync(1))
        .ReturnsAsync(vendorCategory);

      // Act
      var actualVendorCategory = await _agentSecureVendorCategoryService.DeleteVendorCategoryAsync(1);

      // Assert
      _mockVendorCategoryRepository.Verify(repo => repo.DeleteVendorCategoryAsync(1), Times.Once);
      Assert.NotNull(actualVendorCategory);
    }

    [Fact]
    public async Task DeleteVendorCategoryAsync_InvalidId_ShouldReturnNull()
    {
      // Arrange
      _mockVendorCategoryRepository.Setup(repo => repo.DeleteVendorCategoryAsync(999)).ReturnsAsync((VendorCategory?)null!);

      // Act
      var actualVendorCategory = await _agentSecureVendorCategoryService.DeleteVendorCategoryAsync(999);

      // Assert
      _mockVendorCategoryRepository.Verify(repo => repo.DeleteVendorCategoryAsync(999), Times.Once);
      Assert.Null(actualVendorCategory);
    }
  }
}
