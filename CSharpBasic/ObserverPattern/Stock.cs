using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestorObserver> investors = new List<IInvestorObserver>();
        // Constructor
        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(IInvestorObserver investor)
        {
            investors.Add(investor);
        }
        public void Detach(IInvestorObserver investor)
        {
            investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (IInvestorObserver investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        // Gets or sets the price
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }
        // Gets the symbol
        public string Symbol
        {
            get { return symbol; }
        }
    }
}
