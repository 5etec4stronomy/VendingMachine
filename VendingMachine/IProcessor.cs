using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IProcessor
    {
        List<Coin> CurrentTransaction { get; }
        List<Coin> CoinReturn { get; }
        List<Product> Products { get; set; }

        decimal CurrentTransactionBalance { get; }
        bool ProductDispensed { get; }

        void AcceptCoin(Coin coin);
        void SelectProduct(ProductType productType);
        void ReturnCoins();
    }
}
