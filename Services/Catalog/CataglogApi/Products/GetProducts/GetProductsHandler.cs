namespace CataglogApi.Products.GetProducts
{

    public record GetProductQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);
    
    
   internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger):IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProducts");
            
            var products = await session.Query<Product>().ToListAsync();
            return new GetProductsResult(products);
        }
    }
}