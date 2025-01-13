
//public record GetProductByIdRequest(string Id)
public record GetProductByIdResponse(Product product);
namespace CataglogApi.Products.GetProductById
{
    public class GetProductByIdEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id:guid}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetProductByIdResponse>();
                
                return Results.Ok(response);
            }).WithName("GetProductByIdEndpoint")
            .WithDescription("Gets a product by id")
            .Produces<GetProductByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest);;
        }
    }
}