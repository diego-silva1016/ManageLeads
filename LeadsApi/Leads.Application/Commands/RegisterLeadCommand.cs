using MediatR;

namespace Leads.Application.Commands;

public class RegisterLeadCommand : IRequest<bool>
{
    public string FirstName { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Category { get; set; }
    public string Suburb { get; set; }
    public decimal Price { get; set; }
}
