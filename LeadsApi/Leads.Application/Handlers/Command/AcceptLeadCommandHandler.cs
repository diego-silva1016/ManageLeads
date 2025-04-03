using Leads.Application.Commands;
using Leads.Application.Interfaces;
using Leads.Application.Notification;
using Leads.Domain.Enums;
using Leads.Domain.Services.Interface;
using MediatR;

namespace Leads.Application.Handlers.Command;

public class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand, bool>
{
    private ILeadRepository _leadRepository;
    private ILeadsService _leadsService;
    private IMediator _mediator;

    public AcceptLeadCommandHandler(ILeadRepository leadRepository, ILeadsService leadsService, IMediator mediator)
    {
        _leadRepository = leadRepository;
        _leadsService = leadsService;
        _mediator = mediator;
    }

    public async Task<bool> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = _leadRepository.GetLeadsById(request.Id);

        var price = _leadsService.VerifyAndCalcDiscount(lead.Lead.Price);

        await _leadRepository.AcceptLead(request.Id, (int)StatusLead.Accepted, price);

        await _mediator.Publish(new LeadAcceptedNotification());

        return true;
    }
}
