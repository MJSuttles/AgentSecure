using Xunit;
using Moq;
using AgentSecure.Repositories;
using AgentSecure.Services;
using AgentSecure.Models;
using AgentSecure.Interfaces;
using AgentSecure.DTOs;
using System.Threading.Tasks;

// namespace AgentSecure.Tests
// {
//   public class VendorTests
//   {
//     [Fact]
//     public void Test1()
//     {
//       // Arrange

//       bool isVendorActive = false;

//       // Act

//       isVendorActive = true;


//       // Assert
//       Assert.True(isVendorActive, "Vendor should be active");
//     }
//   }
// }

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
          Categories = new List<string> { "Luxury", "Cruises"}
        },
        new VendorDto{
          Id =2,
          Name = "Vendor 2",
          Website = "www.vendor2.com",
          LoginWebsite = "www.login.vendor2.com",
          Phone = "444-555-6666",
          Consortium = "Consortium B",
          Description = "Test Vendor 2",
          Categories = new List<string> { "Adventure", "Tours"}
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
        Description = "A test vendor"
      };

      _mockVendorRepository.Setup(repo => repo.GetVendorByIdAsync(vendorId)).ReturnsAsync(expectedVendor);

      // Arrange

      var actualVendor = await _agentSecureVendorService.GetVendorByIdAsync(vendorId);

      // Assert
      Assert.Equal(expectedVendor, actualVendor);
    }

    [Fact]
    public async Task GetVendorByIdAsync_ShouldReturnNull_WhenVendorDoesNotExist()
    {
      // Act
      var actualVendor = await _agentSecureVendorService.GetVendorByIdAsync(4);

      // Assert
      Assert.Null(actualVendor);
    }

  }
}
