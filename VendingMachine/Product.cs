using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Product
    {
        public ProductType ProductType { get; set; }
        public decimal SellPrice { get; set; }
        public int StockLevel { get; set; }
    }

    public enum ProductType
    {
        Cola,
        Chips,
        Candy
    }
}
