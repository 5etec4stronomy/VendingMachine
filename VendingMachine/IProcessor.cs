using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IProcessor
    {
        List<Coin> CurrentTransaction { get; }
        List<Coin> CoinReturn { get; }

        decimal CurrentTransactionBalance { get; }
        bool SelectProductResult { get; }

        void AcceptCoin(Coin coin);
        void SelectProduct();
    }
}
