
using Catalog.API.Models;

namespace Catalog.API.Products.DeleteProduct
{
	public record DeleteProductCommand(Guid Id) : ICommand<bool>;
	internal class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, bool>
	{
		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			session.Delete<Product>(request.Id);
			await session.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
