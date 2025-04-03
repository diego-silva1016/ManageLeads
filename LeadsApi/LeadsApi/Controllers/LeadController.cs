using Leads.Application.Commands;
using Leads.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leads.Api.Controllers;

[ApiController]
[Route("api/lead")]
public class LeadController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("invited")]
    public async Task<IActionResult> GetInvitedLeads()
    {
        var result = await _mediator.Send(new GetInvitedLeadsQuery());
        return result.Count > 0 ? Ok(result) : NoContent();
    }

    [HttpGet("accepted")]
    public async Task<IActionResult> GetAcceptedLeads()
    {
        var result = await _mediator.Send(new GetAcceptedLeadsQuery());
        return result.Count > 0 ? Ok(result) : NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterLead([FromBody] RegisterLeadCommand command)
    {
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest();
    }

    [HttpPut("accept")]
    public async Task<IActionResult> AcceptLead([FromBody] AcceptLeadCommand command)
    {
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest();
    }

    [HttpPut("decline")]
    public async Task<IActionResult> DeclineLead([FromBody] DeclineLeadCommand command)
    {
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest();
    }
}
