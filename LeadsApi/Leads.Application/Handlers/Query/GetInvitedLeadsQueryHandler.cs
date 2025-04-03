using Leads.Application.DTOs;
using Leads.Application.Interfaces;
using Leads.Application.Queries;
using Leads.Domain.Enums;
using MediatR;

namespace Leads.Application.Handlers.Query;

public class GetInvitedLeadsQueryHandler : IRequestHandler<GetInvitedLeadsQuery, List<LeadDto>>
{
    private ILeadRepository _leadRepository;

    public GetInvitedLeadsQueryHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public Task<List<LeadDto>> Handle(GetInvitedLeadsQuery request, CancellationToken cancellationToken)
    {
        var invitedLeads = _leadRepository.GetLeadsByStatus((int)StatusLead.Invited);

        return Task.FromResult(invitedLeads.Select(il => new LeadDto()
        {
            Id = il.Lead.Id,
            FirstName = il.Lead.FirstName,
            Category = il.Category.Description,
            Suburb = il.Suburb.Description,
            Status = il.Lead.Status,
            Price = il.Lead.Price,
            Description = il.Lead.Description,
            DateCreated = il.Lead.DateCreated
        }).ToList());
    }
}
