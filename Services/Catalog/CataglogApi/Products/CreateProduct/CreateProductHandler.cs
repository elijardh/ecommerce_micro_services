

namespace CataglogApi.Products.CreateProduct;


public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //create a product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            ImageFile =  command.ImageFile,
            Category = command.Category,
            Price = command.Price,
        };
        //Save Database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        //Return the result n
        return new CreateProductResult(product.Id);
    }
}
