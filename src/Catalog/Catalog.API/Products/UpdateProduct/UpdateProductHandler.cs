using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
	public record UpdateProductCommand(ProductDto Product) : ICommand<CreateProductResult>;
	internal class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, CreateProductResult>
	{
		public async Task<CreateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
		{
			var existingProduct = await session.LoadAsync<Product>(command.Product.Id, cancellationToken);

			if(existingProduct is null)
			{
				throw new InvalidOperationException("Product not found");
			}

			var product = command.Product.Adapt(existingProduct);
			session.Update(product);
			await session.SaveChangesAsync(cancellationToken);
			return new CreateProductResult(product.Id);
		}
	}
}
