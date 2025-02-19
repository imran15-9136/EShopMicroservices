
namespace Catalog.API.Products.CreateProduct
{

	public record CreateProductCommand(ProductDto Product): ICommand<CreateProductResult>;
	public record CreateProductResult(Guid Id);
	internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
	{
		public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
		{
			var product = command.Adapt<Models.Product>();

			session.Store(product);
			await session.SaveChangesAsync(cancellationToken);
			return new CreateProductResult(product.Id);
		}
	}

}
