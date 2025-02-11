using System;
using System.Collections.Generic;
using System.Linq;
using TradeCategorizer.Domain.Entities;
using TradeCategorizer.Domain.Services;

public class TradeService
{
    private readonly List<ICategorizer> _categorizers;

    public TradeService()
    {
        _categorizers = new List<ICategorizer>
        {
            new ExpiredCategorizer(),
            new HighRiskCategorizer(),
            new MediumRiskCategorizer()
        };
    }

    public List<(Trade Trade, string Category)> CategorizeTrades(List<Trade> trades, DateTime referenceDate)
    {
        var categorizedTrades = new List<(Trade Trade, string Category)>();
        foreach (var trade in trades)
        {
            string category = null;
            foreach (var categorizer in _categorizers)
            {
                category = categorizer.Categorize(trade, referenceDate);
                if (category != null) break;
            }
            categorizedTrades.Add((trade, category ?? "UNCATEGORIZED"));
        }
        return categorizedTrades;
    }
}
