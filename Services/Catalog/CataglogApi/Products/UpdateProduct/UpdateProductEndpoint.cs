namespace CataglogApi.Products.UpdateProduct
{
    public record UpdateProductRequest(
        Guid Id,
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price);
    
    public record UpdateProductResult(Product Product);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {   
            app.MapPut("api/products/", async (UpdateProductRequest request, ISender sender) =>
                {var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                Console.WriteLine($"result: {result.Product.Name}");
                //TODO: Fix addpating issue
                var response = result.Adapt<UpdateProductResult>();
                Console.WriteLine($"response: {response?.Product?.Name??"NO Name"} | {response?.Product?.Description??"No Description"}");
                return Results.Ok(result);
            }).WithName("UpdateProductEndpoint")
                .WithDescription("Updates a product")
                .Produces<UpdateProductResult>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}