using AspNetCoreCleanArchitecture.Contracts.Results.Product;
using MediatR;

namespace AspNetCoreCleanArchitecture.Application.Queries.Product;

public class GetProductQuery : IRequest<GetProductResult>
{
    public Guid ProductId { get; }

    public GetProductQuery(Guid productId)
    {
        ProductId = productId;
    }
}