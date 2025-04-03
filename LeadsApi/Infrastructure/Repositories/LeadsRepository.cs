using Leads.Application.Interfaces;
using Leads.Domain.Aggregates;
using Leads.Domain.Enums;
using Leads.Infrastructure.Context;
using Leads.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.Repositories;

public class LeadsRepository : ILeadRepository
{
    private readonly LeadsDbContext _context;
    private readonly DbSet<LeadEntity> _dbSet;

    public LeadsRepository(LeadsDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<LeadEntity>();
    }

    public async Task<bool> AddLead(LeadAggregate leadAggregate)
    {
        var newLead = new LeadEntity()
        {
            FirstName = leadAggregate.Lead.FirstName,
            FullName = leadAggregate.Lead.FullName,
            Description = leadAggregate.Lead.Description,
            Email = leadAggregate.Email.EmailAddress,
            PhoneNumber = leadAggregate.PhoneNumber.Number,
            Category = leadAggregate.Category.Description,
            Suburb = leadAggregate.Suburb.Description,
            Price = leadAggregate.Lead.Price,
            Status = (int)leadAggregate.Lead.Status,
            DateCreated = DateTime.Now
        };

        var entity = _context.Leads.Add(newLead);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> UpdateLeadStatus(int id, int status)
    {
        await _context.Leads
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(l => l.Status, status));

        return true;
    }

    public async Task<bool> AcceptLead(int id, int status, decimal price)
    {
        await _context.Leads
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(l => l.Status, status)
                                                    .SetProperty(l => l.Price, price));

        return true;
    }

    public List<LeadAggregate> GetLeadsByStatus(int status)
    {
        var leads = _context.Leads.AsQueryable().Where(l => l.Status == status);

        return leads.Select(l =>
        new LeadAggregate()
        {
            Lead = new Domain.Entities.Lead(l.Id, l.FirstName, l.FullName, l.Description, l.Price, (StatusLead)l.Status, l.DateCreated),
            PhoneNumber = new Domain.ValueObjects.PhoneNumber(l.PhoneNumber),
            Email = new Domain.ValueObjects.Email(l.Email),
            Suburb = new Domain.ValueObjects.Suburb(l.Suburb),
            Category = new Domain.ValueObjects.Category(l.Category)
        }).ToList();
    }

    public LeadAggregate GetLeadsById(int id)
    {
        var lead = _context.Leads.First(l => l.Id == id);

        return new LeadAggregate()
        {
            Lead = new Domain.Entities.Lead(lead.Id, lead.FirstName, lead.FullName, lead.Description, lead.Price, (StatusLead)lead.Status, lead.DateCreated),
            PhoneNumber = new Domain.ValueObjects.PhoneNumber(lead.PhoneNumber),
            Email = new Domain.ValueObjects.Email(lead.Email),
            Suburb = new Domain.ValueObjects.Suburb(lead.Suburb),
            Category = new Domain.ValueObjects.Category(lead.Category)
        };
    }
}
