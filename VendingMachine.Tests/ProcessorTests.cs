using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class ProcessorTests
    {
        private IProcessor _sut;
        private IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _display = new Display();

            _sut = new Processor(_display, new CoinValidator())
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Cola, SellPrice = 1, StockLevel = 5 },
                    new Product { ProductType = ProductType.Chips, SellPrice = 0.5m, StockLevel = 10 },
                    new Product { ProductType = ProductType.Candy, SellPrice = 0.65m, StockLevel = 15 }
                }
            };
        }

        [Test]
        public void DefaultMessage_SetMessage_ReturnsCorrectMessage()
        {
            Assert.AreEqual("INSERT COIN", _display.Message);
        }

        [Test]
        public void AcceptCoin_InsertSingleCoin_ReturnsCurrentBalance()
        {
            _sut.AcceptCoin(new Coin { Diameter = 17.91m, Weight = 2.268m } );

            Assert.AreEqual(0.1m, _sut.CurrentTransactionBalance);
        }

        [Test]
        public void AcceptCoin_InsertMultipleCoins_ReturnsCurrentBalance()
        {
            _sut.AcceptCoin(new Coin { Diameter = 21.21m, Weight = 5 });
            _sut.AcceptCoin(new Coin { Diameter = 17.91m, Weight = 2.268m });


            Assert.AreEqual(0.15m, _sut.CurrentTransactionBalance);
        }

        [Test]
        public void AcceptCoin_InvalidCoin_ReturnsRejectedCoin()
        {
            var invalidCoin = new Coin { Diameter = 20m, Weight = 6 };

            _sut.AcceptCoin(invalidCoin);

            Assert.AreEqual(1, _sut.CoinReturn.Count);
            Assert.AreEqual(invalidCoin, _sut.CoinReturn[0]);
        }

        [Test]
        public void SelectProduct_EnoughMoney_ReturnsProductAndTHANKYOUMessage()
        {        
            //test adding 10 dimes
            var testCoin = new Coin { Diameter = 17.91m, Weight = 2.268m };

            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);

            _sut.SelectProduct(ProductType.Cola);

            Assert.IsTrue(_sut.ProductDispensed);
            Assert.AreEqual("THANK YOU", _display.Message);
            Assert.AreEqual(0m, _sut.CurrentTransactionBalance);
        }

        [Test]
        public void SelectProduct_NotEnoughMoney_ReturnsPRICEMessage()
        {
            var testCoin = new Coin { Diameter = 17.91m, Weight = 2.268m };

            //add two dimes, which won't be enough
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);

            _sut.SelectProduct(ProductType.Cola);

            Assert.IsFalse(_sut.ProductDispensed);
            Assert.AreEqual("PRICE 1.00", _display.Message);
            Assert.AreEqual(0.2m, _sut.CurrentTransactionBalance);
        }

        [Test]
        public void SelectProduct_TooMuchMoney_ReturnsTHANKYOUMessageAndChange()
        {
            var testCoin = new Coin { Diameter = 17.91m, Weight = 2.268m };

            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);
            _sut.AcceptCoin(testCoin);

            _sut.SelectProduct(ProductType.Cola);
        }
    }
}
