
namespace CataglogApi.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool Success);
    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger): ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
           logger.LogInformation("Delete product {@command}", command);
           session.Delete<Product>(command.Id);
           await  session.SaveChangesAsync(cancellationToken);
           return new DeleteProductResult(true);
        }
    }
}