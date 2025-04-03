using Leads.Application.DTOs;
using MediatR;

namespace Leads.Application.Queries;

public class GetInvitedLeadsQuery : IRequest<List<LeadDto>>
{
}
