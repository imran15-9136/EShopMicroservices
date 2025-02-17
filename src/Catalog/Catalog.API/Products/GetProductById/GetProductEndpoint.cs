using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.GetProductById
{
	public record GetProductResponse(Product Product);
	public class GetProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/product/{id}", async (Guid id, ISender sender) =>
			{
				var result = await sender.Send(new GetProductQuery(id));
				var response = result.Adapt<GetProductResponse>();
				return Results.Ok(response);
			})	.WithName("productById")
				.Produces<CreateProductResponse>(StatusCodes.Status201Created)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.WithSummary("Create Product")
				.WithDescription("Create a new product.");
		}
	}
}
