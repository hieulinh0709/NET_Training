using System;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Circle circle = new Circle { Radius = 5 };

            AreaCalculator areaCalculator = new AreaCalculator();

            var dienTich = areaCalculator.TotalArea(circle);
        }
    }
}
