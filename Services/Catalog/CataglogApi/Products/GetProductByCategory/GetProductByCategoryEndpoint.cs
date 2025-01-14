
namespace CataglogApi.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products/category/{category}", async (String category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResponse>();
                
                return Results.Ok(response);
                
            }).WithName("GetProductByCategoryEndpoint")
                .WithDescription("Get product by Category")
                .Produces<GetProductByIdResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}