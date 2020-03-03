using System;

namespace VendingMachine
{
    public class Processor : IProcessor
    {
        public Decimal CurrentBalance { get; private set; }

        private readonly IDisplay _display;

        public Processor(IDisplay display)
        {
            _display = display;

            _display.SetMessage("INSERT COIN");
        }

        public void AcceptCoin(decimal coinValue)
        {
            CurrentBalance += coinValue;
        }
    }
}
