using Leads.Application.Commands;
using Leads.Application.Interfaces;
using Leads.Domain.Aggregates;
using Leads.Domain.Enums;
using MediatR;

namespace Leads.Application.Handlers.Command;

public class RegisterLeadCommandHandler : IRequestHandler<RegisterLeadCommand, bool>
{
    private ILeadRepository _leadRepository;

    public RegisterLeadCommandHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<bool> Handle(RegisterLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = new LeadAggregate()
        {
            Lead = new Domain.Entities.Lead(request.FirstName, request.FullName, request.Description, request.Price, StatusLead.Invited),
            PhoneNumber = new Domain.ValueObjects.PhoneNumber(request.PhoneNumber),
            Email = new Domain.ValueObjects.Email(request.Email),
            Suburb = new Domain.ValueObjects.Suburb(request.Suburb),
            Category = new Domain.ValueObjects.Category(request.Category)
        };

        return await _leadRepository.AddLead(lead);
    }
}
