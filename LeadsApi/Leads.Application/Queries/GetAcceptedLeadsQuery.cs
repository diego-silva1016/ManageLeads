using Leads.Application.DTOs;
using MediatR;

namespace Leads.Application.Queries;

public class GetAcceptedLeadsQuery : IRequest<List<LeadDto>>
{
}
