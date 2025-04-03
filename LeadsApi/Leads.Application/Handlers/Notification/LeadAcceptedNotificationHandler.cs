using Leads.Application.Email.Interface;
using Leads.Application.Notification;
using MediatR;

namespace Leads.Application.Handlers.Notification;

public class LeadAcceptedNotificationHandler : INotificationHandler<LeadAcceptedNotification>
{
    private readonly IEmailService _emailService;

    public LeadAcceptedNotificationHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task Handle(LeadAcceptedNotification notification, CancellationToken cancellationToken)
    {
        await _emailService.SendLeadAcceptedEmail();
    }
}
