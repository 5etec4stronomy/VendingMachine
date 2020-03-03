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
    }
}
