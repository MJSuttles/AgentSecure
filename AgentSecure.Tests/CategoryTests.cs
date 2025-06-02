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
  public class CategoryTests
  {
    private readonly AgentSecureCategoryService _agentSecureCategoryService;
    private readonly Mock<IAgentSecureCategoryRepository> _mockCategoryRepository;

    public CategoryTests()
    {
      _mockCategoryRepository = new Mock<IAgentSecureCategoryRepository>();
      _agentSecureCategoryService = new AgentSecureCategoryService(_mockCategoryRepository.Object);
    }

    // Test for GetAllCategoriesAsync

    [Fact]
    public async Task GetAllCategoriesAsync_ShouldReturnListOfCategories()
    {
      // Arrange
      var expectedCategories = new List<Category>
      {
        new Category
        {
          Id = 1,
          CatName = "Luxury travel experiences"
        },
        new Category
        {
          Id = 2,
          CatName = "Adventure travel experiences"
        }
      };

      _mockCategoryRepository.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(expectedCategories);

      // Act
      var actualCategories = await _agentSecureCategoryService.GetAllCategoriesAsync();

      // Assert
      _mockCategoryRepository.Verify(repo => repo.GetAllCategoriesAsync(), Times.Once);
      Assert.Equal(expectedCategories.Count, actualCategories.Count);
      Assert.Equal(expectedCategories[0].CatName, actualCategories[0].CatName);
      Assert.Equal(expectedCategories[1].CatName, actualCategories[1].CatName);
    }

    // Tests for GetCategoryByIdAsync

    [Fact]
    public async Task GetCategoryByIdAsync_ValidId_ShouldReturnCategory()
    {
      // Arrange
      var expectedCategory = new Category
      {
        Id = 1,
        CatName = "Luxury travel experiences"
      };

      _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(1)).ReturnsAsync(expectedCategory);

      // Act
      var actualCategory = await _agentSecureCategoryService.GetCategoryByIdAsync(1);

      // Assert
      _mockCategoryRepository.Verify(repo => repo.GetCategoryByIdAsync(1), Times.Once);
      Assert.NotNull(actualCategory);
      Assert.Equal(expectedCategory.CatName, actualCategory.CatName);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_InvalidId_ShouldReturnNull()
    {
      // Arrange
      _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(999)).ReturnsAsync((Category?)null);

      // Act
      var actualCategory = await _agentSecureCategoryService.GetCategoryByIdAsync(999);

      // Assert
      _mockCategoryRepository.Verify(repo => repo.GetCategoryByIdAsync(999), Times.Once);
      Assert.Null(actualCategory);
    }

    // Test for CreateCategoryAsync

    [Fact]
    public async Task CreateCategoryAsync_ValidCategory_ShouldReturnCreatedCategory()
    {
      // Arrange
      var newCategory = new Category
      {
        Id = 3,
        CatName = "Cultural travel experiences"
      };

      _mockCategoryRepository.Setup(repo => repo.CreateCategoryAsync(newCategory)).ReturnsAsync(newCategory);

      // Act
      var createdCategory = await _agentSecureCategoryService.CreateCategoryAsync(newCategory);

      // Assert
      _mockCategoryRepository.Verify(repo => repo.CreateCategoryAsync(newCategory), Times.Once);
      Assert.NotNull(createdCategory);
      Assert.Equal(newCategory.CatName, createdCategory.CatName);
    }

    // Tests for UpdateCategoryAsync

    [Fact]
    public async Task UpdateCategoryAsync_ValidId_ShouldReturnUpdatedCategory()
    {
      // Arrange
      var updatedCategory = new Category
      {
        Id = 1,
        CatName = "Updated Luxury travel experiences"
      };

      _mockCategoryRepository.Setup(repo => repo.UpdateCategoryAsync(1, updatedCategory)).ReturnsAsync(updatedCategory);

      // Act
      var result = await _agentSecureCategoryService.UpdateCategoryAsync(1, updatedCategory);

      // Assert
      _mockCategoryRepository.Verify(repo => repo.UpdateCategoryAsync(1, updatedCategory), Times.Once);
      Assert.NotNull(result);
      Assert.Equal(updatedCategory.CatName, result.CatName);
    }

    // Tests for DeleteCategoryAsync

    [Fact]
    public async Task DeleteCategoryAsync_ValidId_ShouldReturnDeletedCategory()
    {
      // Arrange
      var deletedCategory = new Category
      {
        Id = 1,
        CatName = "Luxury travel experiences"
      };

      _mockCategoryRepository.Setup(repo => repo.DeleteCategoryAsync(1)).ReturnsAsync(deletedCategory);

      // Act
      var result = await _agentSecureCategoryService.DeleteCategoryAsync(1);

      // Assert
      _mockCategoryRepository.Verify(repo => repo.DeleteCategoryAsync(1), Times.Once);
      Assert.NotNull(result);
      Assert.Equal(deletedCategory.CatName, result.CatName);
    }

    [Fact]
    public async Task DeleteCategoryAsync_InvalidId_ShouldReturnNull()
    {
      // Arrange
      _mockCategoryRepository.Setup(repo => repo.DeleteCategoryAsync(999)).ReturnsAsync((Category?)null);

      // Act
      var result = await _agentSecureCategoryService.DeleteCategoryAsync(999);

      // Assert
      _mockCategoryRepository.Verify(repo => repo.DeleteCategoryAsync(999), Times.Once);
      Assert.Null(result);
    }
  }
}
