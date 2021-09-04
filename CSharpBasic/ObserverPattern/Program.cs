using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Create IBM stock and attach investors
            IBMConcreteSubject ibm = new IBMConcreteSubject("IBM", 120.00);
            ibm.Attach(new InvestorConcreteObserver("Sorros"));
            ibm.Attach(new InvestorConcreteObserver("Berkshire"));
            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
            // Wait for user
            Console.ReadKey();
        }
    }
}
