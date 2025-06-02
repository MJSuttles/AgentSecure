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
  public class VendorTests
  {
    private readonly AgentSecureVendorService _agentSecureVendorService;
    private readonly Mock<IAgentSecureVendorRepository> _mockVendorRepository;

    public VendorTests()
    {
      _mockVendorRepository = new Mock<IAgentSecureVendorRepository>();
      _agentSecureVendorService = new AgentSecureVendorService(_mockVendorRepository.Object);
    }

    [Fact]
    public async Task GetAllVendorsAsync_ShouldReturnListOfVendors()
    {
      // Arrange
      var expectedVendors = new List<VendorDto>
      {
        new VendorDto
        {
          Id = 1,
          Name = "Vendor 1",
          Website = "www.vendor1.com",
          LoginWebsite = "www.login.vendor1.com",
          Phone = "111-222-3333",
          Consortium = "Consortium A",
          Description = "Test Vendor 1",
          Categories = new List<string> { "Luxury", "Cruises" }
        },
        new VendorDto
        {
          Id = 2,
          Name = "Vendor 2",
          Website = "www.vendor2.com",
          LoginWebsite = "www.login.vendor2.com",
          Phone = "444-555-6666",
          Consortium = "Consortium B",
          Description = "Test Vendor 2",
          Categories = new List<string> { "Adventure", "Tours" }
        }
      };

      _mockVendorRepository.Setup(repo => repo.GetAllVendorsAsync()).ReturnsAsync(expectedVendors);

      // Act
      var actualVendors = await _agentSecureVendorService.GetAllVendorsAsync();

      // Assert
      Assert.Equal(expectedVendors.Count, actualVendors.Count);
      Assert.Equal(expectedVendors[0].Name, actualVendors[0].Name);
      Assert.Equal(expectedVendors[1].Name, actualVendors[1].Name);
    }

    [Fact]
    public async Task GetVendorByIdAsync_ShouldReturnVendor_WhenVendorExists()
    {
      // Arrange
      var vendorId = 1;
      var expectedVendor = new VendorDto
      {
        Id = vendorId,
        Name = "Vendor 1",
        Website = "www.fakevendor1.com",
        LoginWebsite = "www.login.fake",
        Phone = "555-444-3333",
        Consortium = "Vax",
        Description = "A test vendor",
        Categories = new List<string> { "Luxury" }
      };

      _mockVendorRepository.Setup(repo => repo.GetVendorByIdAsync(vendorId)).ReturnsAsync(expectedVendor);

      // Act
      var actualVendor = await _agentSecureVendorService.GetVendorByIdAsync(vendorId);

      // Assert
      Assert.NotNull(actualVendor);
      Assert.Equal(expectedVendor.Name, actualVendor.Name);
    }

    [Fact]
    public async Task GetVendorByIdAsync_ShouldReturnNull_WhenVendorDoesNotExist()
    {
      // Arrange
      int vendorId = 999;
      _mockVendorRepository.Setup(repo => repo.GetVendorByIdAsync(vendorId)).ReturnsAsync((VendorDto?)null);

      // Act
      var actualVendor = await _agentSecureVendorService.GetVendorByIdAsync(vendorId);

      // Assert
      Assert.Null(actualVendor);
    }

    [Fact]
    public async Task CreateVendorAsync_ShouldReturnCreatedVendor()
    {
      // Arrange
      var newVendor = new Vendor
      {
        Name = "New Vendor",
        Website = "www.newvendor.com",
        LoginWebsite = "www.login.newvendor.com",
        Phone = "123-456-7890",
        Consortium = "New Consortium",
        Description = "A new vendor for testing"
      };

      _mockVendorRepository.Setup(repo => repo.CreateVendorAsync(newVendor)).ReturnsAsync(newVendor);

      // Act
      var createdVendor = await _agentSecureVendorService.CreateVendorAsync(newVendor);

      // Assert
      Assert.NotNull(createdVendor);
      Assert.Equal(newVendor.Name, createdVendor.Name);
    }

    [Fact]
    public async Task UpdateVendorAsync_ShouldReturnUpdatedVendor_WhenVendorExists()
    {
      // Arrange
      var vendorId = 1;
      var updatedVendorDto = new VendorUpdateDto
      {
        Name = "Updated Vendor",
        Website = "www.updatedvendor.com",
        LoginWebsite = "www.login.updatedvendor.com",
        Phone = "987-654-3210",
        Consortium = "Updated Consortium",
        Description = "An updated vendor for testing",
        Categories = new List<string> { "Luxury", "Cruises" }
      };

      _mockVendorRepository
        .Setup(repo => repo.UpdateVendorAsync(vendorId, It.Is<VendorUpdateDto>(v =>
          v.Name == updatedVendorDto.Name &&
          v.Website == updatedVendorDto.Website)))
        .ReturnsAsync(updatedVendorDto); // ✅ This is correct

      // Act
      var updatedVendor = await _agentSecureVendorService.UpdateVendorAsync(vendorId, updatedVendorDto);

      // Assert
      Assert.NotNull(updatedVendor);
      Assert.Equal(updatedVendorDto.Name, updatedVendor.Name);
      Assert.Equal(updatedVendorDto.Categories.Count, updatedVendor.Categories.Count);
    }

    [Fact]
    public async Task UpdateVendorAsync_ShouldReturnNull_WhenVendorDoesNotExist()
    {
      // Arrange
      var nonExistentVendorId = 999;
      var updatedVendor = new VendorUpdateDto
      {
        Name = "Non-existent Vendor",
        Website = "www.nonexistentvendor.com",
        LoginWebsite = "www.login.nonexistentvendor.com",
        Phone = "000-000-0000",
        Consortium = "Non-existent Consortium",
        Description = "A vendor that does not exist"
      };

      _mockVendorRepository.Setup(repo => repo.UpdateVendorAsync(nonExistentVendorId, updatedVendor))
        .ReturnsAsync((VendorUpdateDto)null!); // ✅ Correct type

      // Act
      var result = await _agentSecureVendorService.UpdateVendorAsync(nonExistentVendorId, updatedVendor);

      // Assert
      Assert.Null(result);
    }

    // Tests for DeleteVendorAsync

    [Fact]
    public async Task DeleteVendorAsync_ShouldReturnVendor_WhenVendorExists()
    {
      // Arrange
      var vendorId = 1;
      var vendor = new Vendor
      {
        Id = vendorId,
        Name = "Test Vendor",
        Website = "www.testvendor.com",
        LoginWebsite = "www.login.testvendor.com",
        Phone = "123-456-7890",
        Consortium = "Test Consortium",
        Description = "Sample vendor"
      };

      _mockVendorRepository
        .Setup(repo => repo.DeleteVendorAsync(vendorId))
        .ReturnsAsync(vendor); // ✅ Now returning the expected type

      // Act
      var result = await _agentSecureVendorService.DeleteVendorAsync(vendorId);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(vendorId, result.Id);
    }


    [Fact]
    public async Task DeleteVendorAsync_ShouldReturnFalse_WhenVendorDoesNotExist()
    {
      // Arrange
      var vendorId = 999;
      _mockVendorRepository.Setup(repo => repo.DeleteVendorAsync(vendorId)).ReturnsAsync((Vendor?)null);

      // Act
      var result = await _agentSecureVendorService.DeleteVendorAsync(vendorId);

      // Assert
      Assert.Null(result);
    }
  }
}
