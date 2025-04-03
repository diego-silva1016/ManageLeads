namespace Leads.Domain.ValueObjects;

public class Category
{
    public string Description { get; }

    public Category(string description)
    {
        Description = description;
    }
}
