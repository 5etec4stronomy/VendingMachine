using System;

namespace VendingMachine
{
    public class Display : IDisplay
    {
        public string Message { get; set; }

        public void SetMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
