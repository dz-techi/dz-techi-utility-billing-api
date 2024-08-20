using UtilityBilling.Contracts.Requests.Product;
using UtilityBilling.Contracts.Results.Product;
using MediatR;

namespace UtilityBilling.Application.Commands.Product;

public class AddProductCommand : IRequest<GetProductResult?>
{
    public AddProductRequest ProductRequest { get; }

    public AddProductCommand(AddProductRequest productRequest)
    {
        ProductRequest = productRequest;
    }
}