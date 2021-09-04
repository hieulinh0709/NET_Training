using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class InvestorConcreteObserver : IInvestorObserver
    {
        private string name;
        private Stock stock;
        // Constructor
        public InvestorConcreteObserver(string name)
        {
            this.name = name;
        }
        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", name, stock.Symbol, stock.Price);
        }
        // Gets or sets the stock
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
