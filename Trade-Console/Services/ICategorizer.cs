using TradeCategorizer.Domain.Entities;

namespace TradeCategorizer.Domain.Services
{
    public interface ICategorizer
    {
        string Categorize(Trade trade, DateTime referenceDate);
    }
}
