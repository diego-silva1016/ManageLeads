namespace Leads.Domain.ValueObjects;

public class Email
{
    public string EmailAddress { get; }

    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }
}
