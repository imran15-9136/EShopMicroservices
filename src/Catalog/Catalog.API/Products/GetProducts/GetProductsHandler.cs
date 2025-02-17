﻿using Catalog.API.Models;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts
{
	public record GetProductsQuery() : IQuery<GetProductsResult>;
	public record GetProductsResult(IEnumerable<Product> Products);
	public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
	{
		public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
		{
			logger.LogInformation("GetProductsHandeler {@Query}", query);
			var products = await session.Query<Product>().ToListAsync(cancellationToken);
			return new GetProductsResult(products);
		}
	}
}
