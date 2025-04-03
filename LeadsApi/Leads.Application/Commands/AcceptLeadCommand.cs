using MediatR;

namespace Leads.Application.Commands;

public class AcceptLeadCommand : IRequest<bool>
{
    public int Id { get; set; }
}
