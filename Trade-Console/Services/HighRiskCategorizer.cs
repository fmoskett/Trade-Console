using TradeCategorizer.Domain.Entities;

namespace TradeCategorizer.Domain.Services
{
    public class HighRiskCategorizer : ICategorizer
    {
        public string Categorize(Trade trade, DateTime referenceDate)
        {
            return trade.Value >= 1000000 && trade.ClientSector == "Private" ? "HIGHRISK" : null;
        }
    }
}
