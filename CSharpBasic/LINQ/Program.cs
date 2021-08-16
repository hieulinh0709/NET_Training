using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating List
            IList<ProductStore> productList = new List<ProductStore>();

            productList.Add(new ProductStore {
                Category = 1,
                ProductName = "Hard Disk", 
                ProductPrice = 1280, 
                Size = new List<string> { "240GB", "500GB", "1TB" } 
            });
            productList.Add(new ProductStore {
                Category = 2,
                ProductName = "Monitor",
                ProductPrice = 3000,
                Size = new List<string> { "4GB", "8GB", "16GB" }
            });
            productList.Add(new ProductStore {
                Category = 1,
                ProductName = "Monitor",
                ProductPrice = 3500,
                Size = new List<string> { "14.5 Inch", "18 Inch", "24 Inch" }
            });
            productList.Add(new ProductStore { Category = 1, ProductName = "Monitor", ProductPrice = 2000 });
            productList.Add(new ProductStore { Category = 2, ProductName = "SSD Disk", ProductPrice = 3500 });
            productList.Add(new ProductStore { Category = 1, ProductName = "RAM", ProductPrice = 2450 });
            productList.Add(new ProductStore { Category = 2, ProductName = "Processor", ProductPrice = 7680 });
            productList.Add(new ProductStore { Category = 1, ProductName = "Bluetooth", ProductPrice = 540 });
            productList.Add(new ProductStore { Category = 1, ProductName = "Keyboard & Mouse", ProductPrice = 1130 });

            //Select order
            //SelectOrder(productList);

            //Group by
            //GroupBy(productList);

            //ToLookup
            //ToLookup(productList);

            //Methods
            //Methods(productList);

            //Rank
            //Rank();

            //LinqWithArrayList();

            LinqWithDictionary();

        }

        public static void LinqWithDictionary()
        {
            Console.WriteLine("\n\n*************** Linq With Dictionary ***************");
            Dictionary<string, int> productList = new Dictionary<string, int>();

            productList.Add("Hard Disk", 1280);
            productList.Add("Monitor", 3000);
            productList.Add("SSD Disk", 3500);
            productList.Add("RAM", 2450);
            productList.Add("Processor", 7680);
            productList.Add("Bluetooth", 540);
            productList.Add("Keyboard", 1130);

            //Method 1
            var search = from x in productList
                         where x.Key.Contains("Disk")
                         select x;
            //Method 2
            //var search = productList.Where(p => p.Key.Contains("Disk"));

            foreach (var result in search)
            {
                Console.WriteLine("Product Name: {0}, Price: {1}", result.Key, result.Value);
            }
        }
        public static void LinqWithArrayList()
        {
            Console.WriteLine("\n\n*************** Linq With ArrayList ***************");
            ArrayList productList = new ArrayList();
            productList.Add(new ProductStore { ProductName = "Hard Disk", ProductPrice = 1280 });
            productList.Add(new ProductStore { ProductName = "Monitor", ProductPrice = 3000 });
            productList.Add(new ProductStore { ProductName = "SSD Disk", ProductPrice = 3500 });
            productList.Add(new ProductStore { ProductName = "RAM", ProductPrice = 2450 });
            productList.Add(new ProductStore { ProductName = "Processor", ProductPrice = 7680 });
            productList.Add(new ProductStore { ProductName = "Bluetooth", ProductPrice = 540 });
            productList.Add(new ProductStore { ProductName = "Keyboard", ProductPrice = 1130 });

            //Method 1: Mthods Expression
            var search = from ProductStore p in productList
                         where p.ProductName.Contains("Disk")
                         select p;

            foreach (var result in search)
            {
                Console.WriteLine("Product Name: {0}, Price: {1}", result.ProductName, result.ProductPrice);
            }
        }

        public static void Rank()
        {
            Console.WriteLine("\n\n*************** Range ***************");
            Random r = new Random(); // randum number
            IEnumerable<int> squareNumber = Enumerable.Range(4, 8).Select(x => x + r.Next());
            foreach (var num in squareNumber)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\n\n*************** Repeat ***************");
            IEnumerable<int> repeatNumber = Enumerable.Repeat(35, 10);
            foreach (var num in repeatNumber)
            {
                Console.WriteLine(num);
            }
        }

        public static void Methods(IList<ProductStore> productList)
        {
            Console.WriteLine("\n\n*********** Methods ***********");
            var select = productList.Select(p => p.ProductPrice);

            // All
            if (select.All(p => p > 0))
            {
                foreach (var price in select)
                {
                    Console.WriteLine("Product Price : {0}", price);
                }

                Console.WriteLine("Average: " + select.Average());
                Console.WriteLine("Count: " + select.Count());
                Console.WriteLine("Max: " + select.Max());
                Console.WriteLine("Min: " + select.Min());
                Console.WriteLine("Sum: " + select.Sum());
                Console.WriteLine("First Value: " + select.First());
                Console.WriteLine("Last Value: " + select.Last());
                Console.WriteLine("Is 3500 Available? " + select.Contains(3500));
                Console.WriteLine("Element at 4th Position: " + select.ElementAt(3));

                var distinctPrice = select.Distinct();
                Console.WriteLine("\n\n------- Distinct Result --------\n");
                foreach (var price in distinctPrice)
                {
                    Console.WriteLine("Distinct Value: " + price.ToString());
                }
            }

            //Any
            if (select.Any(p => p < 1000))
            {
                Console.WriteLine("has an element less than 0");
            }
        }



        public static void ToLookup(IList<ProductStore> productList)
        {
            Console.WriteLine("\n\n*********** ToLookup ***********");
            var toLookup = productList.ToLookup(p => p.Category);
            foreach (var groupKey in toLookup)
            {
                Console.WriteLine("\nCategory: {0}", groupKey.Key);

                foreach (var product in groupKey)
                {
                    Console.WriteLine("\tProduct Name: {0} | Product Price : {1}", product.ProductName, product.ProductPrice);
                }
            }
        }

        public static void GroupBy(IList<ProductStore> productList)
        {
            Console.WriteLine("\n\n*********** Group by ***********");
            var groupBy = productList.GroupBy(p => p.Category);

            foreach (var groupKey in groupBy)
            {
                Console.WriteLine("\nCategory: {0}", groupKey.Key);

                foreach (var product in groupKey)
                {
                    Console.WriteLine("\tProduct Name: {0} | Product Price : {1}", product.ProductName, product.ProductPrice);
                }
            }
        }

        public static void SelectOrder(IList<ProductStore> productList)
        {
            var result = productList.Select(p => p)
                                    .OrderBy(p => p.ProductName) //sort productName by asc
                                    .ThenByDescending(p => p.ProductPrice) //sort productPrice by desc
                                    .Reverse(); //reverse

            foreach (var list in result)
            {
                Console.WriteLine("Category: {0} | Product Name: {1} | Product Price : {2}", list.Category, list.ProductName, list.ProductPrice);
            }
        }
    }
}
