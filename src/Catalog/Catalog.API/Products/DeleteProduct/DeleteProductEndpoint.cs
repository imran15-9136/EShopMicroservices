namespace Catalog.API.Products.DeleteProduct
{
	public class DeleteProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapDelete("/product/{id}", async (Guid id, ISender sender) =>
			{
				var command = new DeleteProductCommand(id);
				var result = await sender.Send(command);
				return Results.NoContent();
			})
			.WithName("DeleteProduct")
			.Produces<bool>(StatusCodes.Status204NoContent)
			.ProducesProblem(StatusCodes.Status404NotFound)
			.WithSummary("Delete Product")
			.WithDescription("Delete a product.");
		}
	}
}
