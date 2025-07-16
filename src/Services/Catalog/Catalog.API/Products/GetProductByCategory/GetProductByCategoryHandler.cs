
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoyQuery(string Category) : IQuery<GetProductByCategoyResult>;
public record GetProductByCategoyResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler
    (IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoyQuery, GetProductByCategoyResult>
{
    public async Task<GetProductByCategoyResult> Handle(GetProductByCategoyQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductByCategoryQueryHandler.Handle called with {query}");
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);
        return new GetProductByCategoyResult(products);
    }
}
