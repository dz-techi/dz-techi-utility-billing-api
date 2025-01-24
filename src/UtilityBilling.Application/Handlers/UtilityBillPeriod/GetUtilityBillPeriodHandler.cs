using MapsterMapper;
using MediatR;
using UtilityBilling.Application.Exceptions;
using UtilityBilling.Application.Queries.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;
using UtilityBilling.Infrastructure.Repositories.Interfaces;

namespace UtilityBilling.Application.Handlers.UtilityBillPeriod;

public class GetUtilityBillPeriodHandler : IRequestHandler<GetUtilityBillPeriodQuery, GetUtilityBillPeriodResult?>
{
    private readonly IMapper _mapper;
    private readonly IUtilityBillPeriodRepository _utilityBillPeriodRepository;

    public GetUtilityBillPeriodHandler(IMapper mapper, IUtilityBillPeriodRepository utilityBillPeriodRepository)
    {
        _mapper = mapper;
        _utilityBillPeriodRepository = utilityBillPeriodRepository;
    }

    public async Task<GetUtilityBillPeriodResult?> Handle(GetUtilityBillPeriodQuery request, CancellationToken cancellationToken)
    {
        var utilityBillPeriod = await _utilityBillPeriodRepository.GetByIdAsync(request.UtilityBillPeriodId, cancellationToken);
        
        if (utilityBillPeriod == null)
        {
            throw new EntityNotFoundException($"Entity with id: {request.UtilityBillPeriodId} not found");
        }
        
        return _mapper.Map<GetUtilityBillPeriodResult>(utilityBillPeriod);
    }
}