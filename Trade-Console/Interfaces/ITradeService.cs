using TradeCategorizer.Domain.Entities;

namespace TradeCategorizer.Application.Interfaces
{
    public interface ITradeService
    {
        List<(Trade Trade, string Category)> CategorizeTrades(List<Trade> trades, DateTime referenceDate);
    }
}
