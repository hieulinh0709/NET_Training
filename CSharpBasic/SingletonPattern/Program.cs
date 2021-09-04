using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Constructor is protected -- cannot use new
            //Singleton s1 = Singleton.Instance();
            //Singleton s2 = Singleton.Instance();
            //// Test for same instance
            //if (s1 == s2)
            //{
            //    Console.WriteLine("Objects are the same instance");
            //}
            //// Wait for user
            //Console.ReadKey();

            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();
            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }
            // Next, load balance 15 requests for a server
            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + serverName);
            }
            // Wait for user
            Console.ReadKey();
        }
    }
}
