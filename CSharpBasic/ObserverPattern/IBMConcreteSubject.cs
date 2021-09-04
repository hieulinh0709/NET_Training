using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    public class IBMConcreteSubject : Stock
    {
        // Constructor
        public IBMConcreteSubject(string symbol, double price)
            : base(symbol, price)
        {
        }
    }
}
