using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Processor : IProcessor
    {
        private readonly IDisplay _display;

        public Processor(IDisplay display)
        {
            _display = display;

            _display.SetMessage("INSERT COIN");
        }

        public void AcceptCoin()
        {
            throw new NotImplementedException();
        }
    }
}
