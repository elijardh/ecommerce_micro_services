namespace CataglogApi.Products.GetProductByCategory
{
    public  record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger) : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handle get product by Category {@query}", query);

            var product = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync(token: cancellationToken);

            return new GetProductByCategoryResult(product);
        }
    }
}