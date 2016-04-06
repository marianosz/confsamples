using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyExample.SalesStrategy;

namespace StrategyExample.PriceStrategy
{
    public class HighStockPriceStrategy : IPriceStrategy
    {
        public double GetSalePrice(Product product)
        {
            return (product.Price * 0.8) * 1.21;
        }
    }
}
