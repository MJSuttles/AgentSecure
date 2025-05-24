using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Endpoint
{
  public static class CategoryEndpoints
  {
    // The endpoint layer is responsible for handling HTTP requests.
    // The endpoint layer will call the service layer to process business logic.
    // The endpoint layer will return the data to the client.
    // The endpoint layer is the entry point for the client to access the application.
    // We must register this MapWeatherEndpoints method in the Program.cs file.
    // You can click the reference to see where it is registered in the Program.cs file.

    public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/categories").WithTags(nameof(Category));

      // API calls

      // Get All Categories
      group.MapGet("/", async (IAgentSecureCategoryService agentSecureCategoryService) =>
      {
        return await agentSecureCategoryService.GetAllCategoriesAsync();
      })
      .WithName("GetAllCategories")
      .WithOpenApi()
      .Produces<List<Category>>(StatusCodes.Status200OK);

      // Get Category by Id
      group.MapGet("/{id}", async (int id, IAgentSecureCategoryService agentSecureCategoryService) =>
      {
        return await agentSecureCategoryService.GetCategoryByIdAsync(id);
      })
      .WithName("GetCategoryById")
      .WithOpenApi()
      .Produces<Category>(StatusCodes.Status200OK);

      // Create Category
      group.MapPost("/", async (Category category, IAgentSecureCategoryService agentSecureCategoryService) =>
      {
        return await agentSecureCategoryService.CreateCategoryAsync(category);
      })
      .WithName("CreateCategory")
      .WithOpenApi()
      .Produces<Category>(StatusCodes.Status201Created)
      .Produces(StatusCodes.Status400BadRequest);

      // Update Category
      group.MapPut("/{id}", async (int id, Category category, IAgentSecureCategoryService agentSecureCategoryService) =>
      {
        return await agentSecureCategoryService.UpdateCategoryAsync(id, category);
      })
      .WithName("UpdateCategory")
      .WithOpenApi()
      .Produces<Category>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status400BadRequest);

      // Delete Category
    }
  }
}
