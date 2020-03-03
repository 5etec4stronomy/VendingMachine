using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class Processor : IProcessor
    {
        public List<Coin> CurrentTransaction { get; private set; }
        public List<Coin> CoinReturn { get; private set; }
        public List<Product> Products { get; set; }

        public decimal CurrentTransactionBalance => CurrentTransaction.Sum(c => c.Value);
        public bool ProductDispensed { get; private set; }

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

        /// <summary>
        /// Allows the customer to select and purchase a product, assuming they have enough money and it is in stock
        /// </summary>
        /// <param name="productType"></param>
        public void SelectProduct(ProductType productType)
        {
            var selectedProduct = Products.Find(p => p.ProductType == productType);

            if (selectedProduct != null)
            {
                if (CurrentTransactionBalance >= selectedProduct.SellPrice && selectedProduct.StockLevel > 0)
                {
                    //too much money, so issue some change
                    if (CurrentTransactionBalance >= selectedProduct.SellPrice)
                    {
                        IssueChange(CurrentTransactionBalance - selectedProduct.SellPrice);
                    }

                    //dispense the product
                    selectedProduct.StockLevel--;
                    CurrentTransaction.Clear();
                    _display.SetMessage("THANK YOU");

                    ProductDispensed = true;

                }
                else if (CurrentTransactionBalance >= selectedProduct.SellPrice && selectedProduct.StockLevel == 0)
                {
                    //no stock so display the sold out message
                    _display.SetMessage("SOLD OUT");
                }
                else
                {
                    _display.SetMessage($"PRICE {selectedProduct.SellPrice.ToString("N2")}");
                    ProductDispensed = false;
                }
            }
        }

        private void IssueChange(decimal amountToReturn)
        {
            if (CoinReturn == null) CoinReturn = new List<Coin>();

            var valCounter = 0m;
            foreach (var coin in CurrentTransaction)
            {
                valCounter += coin.Value;

                CoinReturn.Add(coin);

                if (amountToReturn == valCounter) return;
            }

        }
    }
}
