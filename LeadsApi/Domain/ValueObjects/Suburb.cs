namespace Leads.Domain.ValueObjects;

public class Suburb
{
    public string Description { get; }

    public Suburb(string description)
    {
        Description = description;
    }
}
