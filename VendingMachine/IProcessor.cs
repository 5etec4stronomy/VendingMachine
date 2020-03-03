using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IProcessor
    {
        List<Coin> CurrentTransaction { get; }

        decimal CurrentTransactionBalance { get; }

        void AcceptCoin(Coin coin);
    }
}
