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
            IProcessor sut = new Processor();
        }
    }
}
