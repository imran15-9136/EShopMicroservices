using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
	public record GetProductsResponse(IEnumerable<Product> Products);
	public class GetProductsEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/products", async (ISender sender) =>
			{
				var products = await sender.Send(new GetProductsQuery());
				var response = products.Adapt<GetProductsResponse>();

				return Results.Ok(response);
			})
			.WithName("GetProduct")
			.Produces<CreateProductResponse>(StatusCodes.Status201Created)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithSummary("Get Product")
			.WithDescription("Get product list.");
		}
	}
}
