using Leads.Domain.Aggregates;

namespace Leads.Application.Interfaces;

public interface ILeadRepository
{
    Task<bool> AddLead(LeadAggregate leadAggregate);
    Task<bool> UpdateLeadStatus(int id, int status);
    Task<bool> AcceptLead(int id, int status, decimal price);
    List<LeadAggregate> GetLeadsByStatus(int status);
    LeadAggregate GetLeadsById(int id);
}
