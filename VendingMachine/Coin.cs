
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Coin
    {
        public CoinType CoinType { get; set; }
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public decimal Diameter { get; set; }
    }

    public enum CoinType
    {
        Nickel,
        Dime,
        Quarter
    }
}
