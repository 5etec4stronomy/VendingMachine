using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class CoinValidatorTests
    {
        [Test]
        public void ValidateCoin_ValidCoin_ReturnsTrue()
        {
            ICoinValidator sut = new CoinValidator();
            sut.ValidateCoin(new Coin());

            var testCoin = new Coin { Diameter = 21.21m, Weight = 5 };

            sut.ValidateCoin(testCoin);

            Assert.IsTrue(sut.CoinValidationResult);
        }
    }
}
