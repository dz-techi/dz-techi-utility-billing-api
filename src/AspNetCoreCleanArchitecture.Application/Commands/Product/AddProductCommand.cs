using AspNetCoreCleanArchitecture.Contracts.Requests.Product;
using AspNetCoreCleanArchitecture.Contracts.Results.Product;
using MediatR;

namespace AspNetCoreCleanArchitecture.Application.Commands.Product;

public class AddProductCommand : IRequest<GetProductResult?>
{
    public AddProductRequest ProductRequest { get; }

    public AddProductCommand(AddProductRequest productRequest)
    {
        ProductRequest = productRequest;
    }
}