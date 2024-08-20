using AspNetCoreCleanArchitecture.Application.Exceptions;
using AspNetCoreCleanArchitecture.Application.Queries.Product;
using AspNetCoreCleanArchitecture.Contracts.Results.Product;
using AspNetCoreCleanArchitecture.Infrastructure.Repositories.Interfaces;
using MapsterMapper;
using MediatR;

namespace AspNetCoreCleanArchitecture.Application.Handlers.Product;

public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResult?>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var productDto = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (productDto == null)
        {
            // TODO: Log message
            throw new EntityNotFoundException($"Entity with id: {request.ProductId} not found");
        }

        return _mapper.Map<GetProductResult>(productDto);
    }
}