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
        private readonly ICoinValidator _coinValidator;

        public Processor(IDisplay display, ICoinValidator coinValidator)
        {
            _display = display;
            _coinValidator = coinValidator;

            _display.SetMessage("INSERT COIN");

        }

        public void AcceptCoin(Coin coin)
        {
            _coinValidator.ValidateCoin(coin);

            if (_coinValidator.MatchedCoinResult.ValidCoin)
            {
                (CurrentTransaction ?? (CurrentTransaction = new List<Coin>())).Add(_coinValidator.MatchedCoinResult.Coin);

            }
        }
    }
}
