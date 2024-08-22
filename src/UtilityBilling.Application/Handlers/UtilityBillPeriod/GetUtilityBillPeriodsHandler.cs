using MapsterMapper;
using MediatR;
using UtilityBilling.Application.Queries.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;
using UtilityBilling.Infrastructure.Repositories.Interfaces;

namespace UtilityBilling.Application.Handlers.UtilityBillPeriod;

public class GetUtilityBillPeriodsHandler : IRequestHandler<GetUtilityBillPeriodsQuery, List<GetUtilityBillPeriodResult>>
{
    private readonly IMapper _mapper;
    private readonly IUtilityBillPeriodRepository _utilityBillPeriodRepository;

    public GetUtilityBillPeriodsHandler(IMapper mapper, IUtilityBillPeriodRepository utilityBillPeriodRepository)
    {
        _mapper = mapper;
        _utilityBillPeriodRepository = utilityBillPeriodRepository;
    }

    public async Task<List<GetUtilityBillPeriodResult>> Handle(GetUtilityBillPeriodsQuery request, CancellationToken cancellationToken)
    {
        // Hardcoded user id.
        var userId = new Guid("99d5d2cf-93e1-4300-ac09-39849738d744");

        var utilityBillPeriods = await _utilityBillPeriodRepository.GetAllByUserIdAsync(userId, cancellationToken);

        return _mapper.Map<List<GetUtilityBillPeriodResult>>(utilityBillPeriods);
    }
}