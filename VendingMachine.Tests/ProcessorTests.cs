using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class ProcessorTests
    {
        [Test]
        public void DefaultMessage_SetMessage_ReturnsCorrectMessage()
        {
            IDisplay display = new Display();
            IProcessor sut = new Processor(display);

            Assert.AreEqual("INSERT COIN", display.Message);
        }
    }
}
