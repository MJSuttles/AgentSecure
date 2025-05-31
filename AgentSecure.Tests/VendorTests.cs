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
    // The BookService class is dependent on the IBookRepository interface.
    // We do not need to mock the Book class because it is a simple class.
    private readonly AgentSecureVendorService _agentSecureVendorService;

    // The Mock class is used to create a mock object of the IBookRepository interface.
    // Mock objects are used to simulate the behavior of real objects.
    // Mock objects are used in unit testing to isolate the code under test.
    // We are mocking the IBookRepository interface because we do not want to test the actual implementation of the BookRepository class.
    // Mock just means that we are creating a fake object that simulates the behavior of the real object.
    private readonly Mock<IAgentSecureVendorRepository> _mockVendorRepository;

    public VendorTests()
    {
      _mockVendorRepository = new Mock<IAgentSecureVendorRepository>();
      _agentSecureVendorService = new AgentSecureVendorService(_mockVendorRepository.Object);
    }

    [Fact]
    public async Task GetVendorByIdAsync_ShouldReturnVendor_WhenVendorExists()
    {
      // Arrange - means to set up the test
      var vendorId = 1;

      // Here, we are creating an instance of the Vendor class with the Id, Name, and IsActive properties set.
      // The expectedVendor does not have to match the actual vendor in the repository.
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


      // The Setup method is used to set up the behavior of the mock object.
      // This means that when the GetVendorById method is called with the vendorId parameter, the mock object should return the expectedVendor instance.
      // The expectedVendor is the object that we set up to be returned by the mock object.
      _mockVendorRepository.Setup(repo => repo.GetVendorByIdAsync(vendorId)).ReturnsAsync(expectedVendor);


      // Act - means to run the test
      // The GetVendorByIdAsync method is called with the vendorId parameter.
      // The actual vendor returned by the GetVendorByIdAsync method comes from the mock object.
      var actualVendor = await _agentSecureVendorService.GetVendorByIdAsync(vendorId);

      // Assert - means to check the result
      // The actualVendor returned by the GetVendorByIdAsync method should be equal to the expectedVendor instance.
      Assert.Equal(expectedVendor, actualVendor);
    }

    [Fact]
    public async Task GetVendorByIdAsync_ShouldReturnNull_WhenVendorDoesNotExist()
    {
      // Act - means to run the test
      // The GetVendorByIdAsync method is called with the vendorId parameter.
      // The actual vendor returned by the GetVendorByIdAsync method comes from the mock object.
      var actualVendor = await _agentSecureVendorService.GetVendorByIdAsync(4);

      // Assert - means to check the result
      // The actualVendor returned by the GetVendorByIdAsync method should be equal to the expectedVendor instance.
      Assert.Null(actualVendor);
    }

  }
}
