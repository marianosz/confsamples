using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyExample.SalesStrategy
{
    public interface IPriceStrategy 
    {
        double GetSalePrice(Product product);
    }
}
