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
            _sut = new Processor(_display, new CoinValidator());
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
    }
}
