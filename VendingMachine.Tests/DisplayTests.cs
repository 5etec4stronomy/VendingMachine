using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class DisplayTests
    {
        [Test]
        public void ShowMessage_ValidMessage_ReturnSuppliedMessage()
        {
            IDisplay sut = new Display();

            sut.SetMessage("Test Message");

            Assert.AreEqual("Test Message", sut.Message);
        }
    }
}