using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class Processor : IProcessor
    {
        public List<Coin> CurrentTransaction { get; private set; }
        public decimal CurrentTransactionBalance => CurrentTransaction.Sum(c => c.Value);

        private readonly IDisplay _display;

        public Processor(IDisplay display)
        {
            _display = display;

            _display.SetMessage("INSERT COIN");

        }

        public void AcceptCoin(Coin coin)
        {
            (CurrentTransaction ?? (CurrentTransaction = new List<Coin>())).Add(coin);
        }
    }
}
