using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
	public class UpdateProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPut("/product/{id}", async (UpdateProductCommand command, ISender sender) =>
			{
				var result = await sender.Send(command);
				return Results.Ok(result);
			})
				.WithName("UpdateProduct")
				.Produces<CreateProductResult>(StatusCodes.Status200OK)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.WithSummary("Update Product")
				.WithDescription("Update an existing product.");
		}
	}
}
