using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyExample.SalesStrategy;

namespace StrategyExample.PriceStrategy
{
    public class LowStockPriceStrategy : IPriceStrategy
    {
        public double GetSalePrice(Product product)
        {
            return (product.Price * 1.2) * 1.21;
        }
    }
}
