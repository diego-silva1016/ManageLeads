using Leads.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.Context;

public class LeadsDbContext : DbContext
{
    public LeadsDbContext(DbContextOptions<LeadsDbContext> options) : base(options) { }

    public DbSet<LeadEntity> Leads { get; set; }
}
