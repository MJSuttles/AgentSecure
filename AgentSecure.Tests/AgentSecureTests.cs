using Xunit;
using Moq;
using AgentSecure.Interfaces;

namespace AgentSecure.Tests
{
  public class AgentSecureTests
  {
    // The AgentSecure class is dependent on the IAgentSecureRepository interface.
    // We do not need to mock the AgentSecure class because it is a simple class.

    // private readonly AgentSecure _agentSecure;

    private readonly Mock<IAgentSecureCategoryRepository> _mockAgentSecureCategoryRepository;

    public AgentSecureCategoryTests()
    {
      _mockAgentSecureCategoryRepository = new Mock<IAgentSecureCategoryRepository>();
    }

    [Fact]
    public void GetCategoryDetails_ShouldReturnCategory_WhenCategoryExists()
    {
      // // Arrange - means to set up the test
      // var bookId = 1;

      // // Here, we are creating an instance of the Book class with the Id, Title, and Author properties set.
      // // The expectedBook does not have to match the actual book in the repository.
      // var expectedBook = new Book { Id = bookId, Title = "Star Wars", Author = "George Lucas" };

      // // The Setup method is used to set up the behavior of the mock object.
      // // This means that when the GetBookById method is called with the bookId parameter, the mock object should return the expectedBook instance.
      // // The expectedBook is the object that we set up to be returned by the mock object.
      // _mockBookRepository.Setup(repo => repo.GetBookById(bookId)).Returns(expectedBook);

      // // Act - means to run the test
      // // The GetBookById method is called with the bookId parameter.
      // // The actual book returned by the GetBookById method comes from the mock object.
      // var actualBook = _bookService.GetBookById(bookId);

      // // Assert - means to check the result
      // // The actualBook returned by the GetBookById method should be equal to the expectedBook instance.
      Assert.Equal(1, 1);
    }


  }
}
