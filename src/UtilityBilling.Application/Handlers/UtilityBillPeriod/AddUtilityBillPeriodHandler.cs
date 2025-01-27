using MapsterMapper;
using MediatR;
using UtilityBilling.Application.Commands.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;
using UtilityBilling.Domain.Exceptions;
using UtilityBilling.Domain.UtilityBillPeriod;
using UtilityBilling.Infrastructure.Repositories.Interfaces;

namespace UtilityBilling.Application.Handlers.UtilityBillPeriod;

public class AddUtilityBillPeriodHandler : IRequestHandler<AddUtilityBillPeriodCommand, GetUtilityBillPeriodResult?>
{
    private readonly IMapper _mapper;
    private readonly IUtilityBillPeriodRepository _utilityBillPeriodRepository;

    public AddUtilityBillPeriodHandler(
        IMapper mapper,
        IUtilityBillPeriodRepository utilityBillPeriodRepository)
    {
        _mapper = mapper;
        _utilityBillPeriodRepository = utilityBillPeriodRepository;
    }

    public async Task<GetUtilityBillPeriodResult?> Handle(AddUtilityBillPeriodCommand request, CancellationToken cancellationToken)
    {
        // Hardcoded user id.
        var userId = new Guid("99d5d2cf-93e1-4300-ac09-39849738d744");
        
        var existingUtilityBillPeriod = await _utilityBillPeriodRepository
            .GetByUserIdAndMonthOfTheYearAsync(userId, request.MonthOfTheYear, cancellationToken);

        if (existingUtilityBillPeriod != null)
        {
            throw new EntityAlreadyExistsException($"Billing period for month of the year: {request.MonthOfTheYear} already exists");
        }

        var utilityBillPeriodDto = new UtilityBillPeriodDto(userId, request.MonthOfTheYear);

        await _utilityBillPeriodRepository.AddAsync(utilityBillPeriodDto, cancellationToken);
        
        return _mapper.Map<GetUtilityBillPeriodResult>(utilityBillPeriodDto);
    }
}