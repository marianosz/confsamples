using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyExample.SalesStrategy;
using StrategyExample.PriceStrategy;

namespace StrategyExample
{
    public class Product
    {
        public double Price { get; private set; }

        public int Stock { get; private set; }

        IPriceStrategy priceStrategy;

        public Product(double price, int stock)
        {
            Price = price;
            Stock = stock;

            SetPriceStrategy();
        }

        public double GetSalePrice()
        {
            return priceStrategy.GetSalePrice(this);
        }

        public void Sell(int quantity)
        {
            if (quantity > Stock)
                Stock -= quantity;
            else
                Stock = 0;

            SetPriceStrategy();
        }

        private void SetPriceStrategy()
        {
            if (Stock < 50)
                priceStrategy = new LowStockPriceStrategy();
            else if (Stock >= 50 && Stock <= 100)
                priceStrategy = new MediunStockPriceStrategy();
            else //if (Stock > 100)
                priceStrategy = new HighStockPriceStrategy();
        }
    }
}
