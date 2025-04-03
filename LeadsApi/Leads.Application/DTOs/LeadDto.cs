using Leads.Domain.Enums;

namespace Leads.Application.DTOs;

public class LeadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Suburb { get; set; }
    public decimal Price { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public StatusLead Status { get; set; }
    public DateTime DateCreated { get; set; }
}
