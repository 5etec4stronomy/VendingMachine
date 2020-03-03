using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class CoinValidator : ICoinValidator
    {
        public MatchedCoinResult MatchedCoinResult { get; private set; }

        public void ValidateCoin(Coin coin)
        {
            var validCoins = new List<Coin>
            {
                new Coin {CoinType = CoinType.Nickel, Value = 0.05m, Diameter = 21.21m, Weight = 5},
                new Coin {CoinType = CoinType.Dime,  Value = 0.1m, Diameter = 17.91m, Weight = 2.268m},
                new Coin {CoinType = CoinType.Quarter, Value = 0.25m, Diameter = 24.26m, Weight = 5.67m},
            };

            MatchedCoinResult = new MatchedCoinResult
            {
                Coin = validCoins.Find(match: c => c.Weight == coin.Weight && coin.Diameter == c.Diameter)
            };
        }
    }
}
