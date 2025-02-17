using Catalog.API.Models;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductById
{
	public record GetProductQuery(Guid id) : IQuery<GetProductResult>;
	public record GetProductResult(Product Product);
	internal class GetProductHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
	{
		public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
		{
			var result = await session.LoadAsync<Product>(query.id, cancellationToken);

			return new GetProductResult(result);
		}
	}
}
