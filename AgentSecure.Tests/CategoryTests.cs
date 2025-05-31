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


  }
}
