namespace Leads.Domain.ValueObjects;

public class PhoneNumber
{
    public string Number { get; }

    public PhoneNumber(string number)
    {
        Number = number;
    }
}
