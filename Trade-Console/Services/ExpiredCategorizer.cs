using TradeCategorizer.Domain.Entities;

namespace TradeCategorizer.Domain.Services
{
    public class ExpiredCategorizer : ICategorizer
    {
        public string Categorize(Trade trade, DateTime referenceDate)
        {
            return trade.NextPaymentDate <= referenceDate.AddDays(-30) ? "EXPIRED" : null;
        }
    }
}
