using System;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDelegate testdelegate = new TestDelegate();
            //Instantiation
            TestDelegate.FirstDelegate fd1 = new TestDelegate.FirstDelegate(testdelegate.fun1);
            TestDelegate.FirstDelegate fd2 = new TestDelegate.FirstDelegate(testdelegate.fun2);
            TestDelegate.FirstDelegate fd3 = new TestDelegate.FirstDelegate(testdelegate.fun3);

            //Invocation 
            fd1();
            fd2();
            fd3();

            Console.ReadKey();
        }
    }
}
