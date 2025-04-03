namespace Leads.Domain.Services.Interface;

public interface ILeadsService
{
    decimal VerifyAndCalcDiscount(decimal price);
}
