using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Endpoint
{
  public static class CategoryEndpoints
  {
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

      group.MapDelete("/{id}", async (int id, IAgentSecureCategoryService agentSecureCategoryService) =>
      {
        var deletedCategory = await agentSecureCategoryService.DeleteCategoryAsync(id);
        if (deletedCategory == null)
        {
          return Results.NotFound($"No category found for Id {id}.");
        }

        return Results.NoContent();
      })
      .WithName("DeleteCategory")
      .WithOpenApi()
      .Produces<Category>(StatusCodes.Status204NoContent)
      .Produces(StatusCodes.Status404NotFound);
    }
  }
}
