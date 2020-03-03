using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IProcessor
    {
        Decimal CurrentBalance { get; }

        void AcceptCoin(decimal coinValue);
    }
}
