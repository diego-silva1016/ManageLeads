using Leads.Domain.Constant;
using Leads.Domain.Services.Interface;

namespace Leads.Domain.Services;

public class LeadsService : ILeadsService
{
    public LeadsService() { }

    public decimal VerifyAndCalcDiscount(decimal price)
    {
        if (price > PriceDiscount.MaxValueWithOutDiscount)
            return price * PriceDiscount.Discount;

        return price;
    }
}
