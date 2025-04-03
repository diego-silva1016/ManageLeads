using Leads.Application.Commands;
using Leads.Application.Interfaces;
using Leads.Application.Notification;
using Leads.Domain.Enums;
using MediatR;

namespace Leads.Application.Handlers.Command;

public class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand, bool>
{
    private ILeadRepository _leadRepository;

    public DeclineLeadCommandHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<bool> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
    {
        return await _leadRepository.UpdateLeadStatus(request.Id, (int)StatusLead.Declined);
    }
}
