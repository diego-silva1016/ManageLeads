using MediatR;

namespace Leads.Application.Commands;

public class DeclineLeadCommand : IRequest<bool>
{
    public int Id { get; set; }
}
