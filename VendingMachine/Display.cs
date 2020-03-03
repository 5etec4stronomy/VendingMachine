using System;

namespace VendingMachine
{
    public class Display : IDisplay
    {
        public string Message { get; set; }

        /// <summary>
        /// Displays the supplied message -- currently this just sets a string, but this interface could be used to drive an external display etc
        /// </summary>
        /// <param name="message">Message to display</param>
        public void SetMessage(string message)
        {
            Message = message;
        }
    }
}
