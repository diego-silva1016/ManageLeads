using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leads.Application.DTOs;
using Leads.Application.Interfaces;
using Leads.Application.Queries;
using Leads.Domain.Enums;
using MediatR;

namespace Leads.Application.Handlers.Query;

public class GetAcceptedLeadsQueryHandler : IRequestHandler<GetAcceptedLeadsQuery, List<LeadDto>>
{
    private ILeadRepository _leadRepository;

    public GetAcceptedLeadsQueryHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public Task<List<LeadDto>> Handle(GetAcceptedLeadsQuery request, CancellationToken cancellationToken)
    {
        var invitedLeads = _leadRepository.GetLeadsByStatus((int)StatusLead.Accepted);

        return Task.FromResult(invitedLeads.Select(il => new LeadDto()
        {
            Id = il.Lead.Id,
            FirstName = il.Lead.FirstName,
            FullName = il.Lead.FullName,
            Category = il.Category.Description,
            Suburb = il.Suburb.Description,
            Status = il.Lead.Status,
            Price = il.Lead.Price,
            Email = il.Email.EmailAddress,
            Phone = il.PhoneNumber.Number,
            Description = il.Lead.Description,
            DateCreated = il.Lead.DateCreated
        }).ToList());
    }
}
