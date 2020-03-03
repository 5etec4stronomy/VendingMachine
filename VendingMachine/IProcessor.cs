using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IProcessor
    {
        List<Coin> CurrentTransaction { get; }
        List<Coin> MachineFloat {  get;}
        List<Coin> CoinReturn { get; }
        List<Product> Products { get; set; }

        decimal CurrentTransactionBalance { get; }
        decimal MachineCoinBalanceTotal { get; }
        bool ProductDispensed { get; }

        void ShowDefaultMessage();
        void AcceptCoin(Coin coin);
        void SelectProduct(ProductType productType);
        void ReturnCoins();
    }
}
