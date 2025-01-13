namespace CataglogApi.Products.GetProducts
{
    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<GetProductResponse>();
                
                return Results.Ok(response);
            }).WithName("GetProducts")
                .WithDescription("Get products")
                .Produces<GetProductResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    } 
}