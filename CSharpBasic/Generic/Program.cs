using System;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Printing Integer Value");
            GenClass<int> gen = new GenClass<int>();
            gen.GenFunction(144);

            Console.WriteLine("Printing String Value");
            GenClass<string> genstring = new GenClass<string>();
            genstring.GenFunction("Hello String");

            //Generic List
            Console.WriteLine("********** Generic List *********");
            genstring.GenDic();

            //Sorted List
            Console.WriteLine("********** Sorted List *********");
            genstring.SortedList();

            //Queue(First In Fist Out)
            Console.WriteLine("********** Queue *********");
            genstring.Queue();

            //Stack(Last Int Firt Out)
            Console.WriteLine("********** Stack *********");
            genstring.Stack();


        }
    }
    
}
