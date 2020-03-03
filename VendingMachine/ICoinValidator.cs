using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface ICoinValidator
    {
        MatchedCoinResult MatchedCoinResult { get; }

        void ValidateCoin(Coin coin);
    }
}
