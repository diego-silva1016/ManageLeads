using Leads.Domain.Entities;
using Leads.Domain.ValueObjects;

namespace Leads.Domain.Aggregates;

public class LeadAggregate
{
    public Lead Lead { get; set; }
    public Email Email { get; set; }
    public Category Category { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Suburb Suburb { get; set; }
}
