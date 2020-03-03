using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface ICoinValidator
    {
        bool CoinValidationResult { get; }

        void ValidateCoin(Coin coin);
    }
}
