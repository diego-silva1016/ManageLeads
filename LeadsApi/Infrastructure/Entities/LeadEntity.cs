using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leads.Infrastructure.Entities;
public class LeadEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Category { get; set; }
    public string Suburb { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "int")]
    public int Status { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }
}

