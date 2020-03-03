using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class CoinValidatorTests
    {
        private ICoinValidator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new CoinValidator();
        }

        [Test]
        public void ValidateCoin_ValidCoin_ReturnsTrue()
        {
            _sut.ValidateCoin(new Coin());

            var testCoin = new Coin { Diameter = 21.21m, Weight = 5 };

            _sut.ValidateCoin(testCoin);

            Assert.IsTrue(_sut.MatchedCoinResult.ValidCoin);
            Assert.AreEqual(CoinType.Nickel, _sut.MatchedCoinResult.Coin.CoinType);
        }

        [Test]
        public void ValidateCoin_InvalidCoin_ReturnsValidCoinResult()
        {
            var testCoin = new Coin { Diameter = 25m, Weight = 6 };

            _sut.ValidateCoin(testCoin);

            Assert.IsFalse(_sut.MatchedCoinResult.ValidCoin);
        }
    }
}
