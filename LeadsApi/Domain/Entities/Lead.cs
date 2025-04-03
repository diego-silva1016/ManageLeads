using Leads.Domain.Enums;

namespace Leads.Domain.Entities;

public class Lead
{
    public int Id { get; }
    public string FirstName { get; }
    public string FullName { get; }
    public string Description { get; }
    public decimal Price { get; }
    public StatusLead Status { get; }
    public DateTime DateCreated { get; }

    public Lead(string firstName, string fullName, string description, decimal price, StatusLead status)
    {
        FirstName = firstName;
        FullName = fullName;
        Description = description;
        Price = price;
        Status = status;
    }

    public Lead(int id, string firstName, string fullName, string description, decimal price, StatusLead status, DateTime dateCreated)
    {
        Id = id;
        FirstName = firstName;
        FullName = fullName;
        Description = description;
        Price = price;
        Status = status;
        DateCreated = dateCreated;
    }
}
