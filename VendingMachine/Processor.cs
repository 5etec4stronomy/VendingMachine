using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class Processor : IProcessor
    {
        public List<Coin> CurrentTransaction { get; private set; }
        public List<Coin> CoinReturn { get; private set; }

        public decimal CurrentTransactionBalance => CurrentTransaction.Sum(c => c.Value);

        private readonly IDisplay _display;
        private readonly ICoinValidator _coinValidator;

        public Processor(IDisplay display, ICoinValidator coinValidator)
        {
            _display = display;
            _coinValidator = coinValidator;

            _display.SetMessage("INSERT COIN");

        }

        /// <summary>
        /// Accepts a coin and allows it to count towards the current transaction if it is found to be valid
        /// </summary>
        /// <param name="coin">Coin to be accepted - must be valid otherwise it will be rejected</param>
        public void AcceptCoin(Coin coin)
        {
            //validate this coin
            _coinValidator.ValidateCoin(coin);

            if (_coinValidator.MatchedCoinResult.ValidCoin)
            {
                //coin is valid so allow it to be used
                (CurrentTransaction ?? (CurrentTransaction = new List<Coin>())).Add(_coinValidator.MatchedCoinResult.Coin);

            }
            else
            {
                RejectCoin(coin);
            }
        }

        /// <summary>
        /// Returns invalid coins to the Coin Reject - using a list to simulate the slot
        /// </summary>
        /// <param name="coin">Coin to be returned</param>
        private void RejectCoin(Coin coin)
        {
            (CoinReturn ?? (CoinReturn = new List<Coin>())).Add(coin);
        }

        public void SelectProduct()
        {
            throw new NotImplementedException();
        }
    }
}
