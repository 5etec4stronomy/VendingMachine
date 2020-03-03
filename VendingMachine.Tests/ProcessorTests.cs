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
            _sut = new Processor(_display);
        }

        [Test]
        public void DefaultMessage_SetMessage_ReturnsCorrectMessage()
        {
            Assert.AreEqual("INSERT COIN", _display.Message);
        }
    }
}
