using Leads.Application.Email.Interface;

namespace Leads.Infrastructure.Email;

public class EmailService : IEmailService
{
    public EmailService() { }

    private readonly string _emailLogPath = "emails.txt";

    public async Task SendLeadAcceptedEmail()
    {
        var message = $"[Email Simulado]\nPara: vendas@test.com,\nAssunto: Lead Aceito";

        await File.AppendAllTextAsync(_emailLogPath, message + "\n====================\n");
    }
}
