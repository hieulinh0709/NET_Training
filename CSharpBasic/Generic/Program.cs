using System;
using System.Collections.Generic;

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

    //Declare Generics 
    public class GenClass<T>
    {
        public void Stack()
        {
            Stack<string> mystack = new Stack<string>();
            //Adding Item in stack
            mystack.Push("Sunday");
            mystack.Push("Monday");
            mystack.Push("Tuesday");
            mystack.Push("Wednesday");
            mystack.Push("Thursday");
            mystack.Push("Friday");
            mystack.Push("Saturday");
            print(mystack);

            //Accessing Top Item without removing it.
            Console.WriteLine("\nTop Item is : {0}", mystack.Peek());

            //Removing Item from Stack
            Console.WriteLine("\nRemoved Top Item of Stack : " + mystack.Pop());
            Console.WriteLine("\nNow Stack's Items are : ");
            print(mystack);
        }

        public static void print(Stack<string> sp)
        {
            foreach (string s in sp)
            {
                Console.Write(s.ToString() + " | ");
            }
        }
        public void Queue()
        {
            Queue<string> student = new Queue<string>();

            //Adding item in queue
            student.Enqueue("Mark");
            student.Enqueue("Jack");
            student.Enqueue("Sarah");
            student.Enqueue("Smith");
            student.Enqueue("Robbie");
            print(student);

            //Removing Item
            Console.WriteLine("\nRemoving {0} from List. \nNew list is : ", student.Dequeue());
            print(student);

            //Copy Array Item to Queue
            string[] city = { "Newyork", "California", "Las Vegas" };
            Queue<string> citylist = new Queue<string>(city);
            Console.WriteLine("\nPrinting City List");
            print(citylist);

            //Count items in Queue
            Console.WriteLine("Count{0}", citylist.Count);
        }

        public static void print(Queue<string> q)
        {
            foreach (string s in q)
            {
                Console.Write(s.ToString() + " | ");
            }
        }

        public void SortedList()
        {
            SortedList<int, string> studentlist = new SortedList<int, string>();
            //Adding some items to sorted list
            studentlist.Add(1, "Jack");
            studentlist.Add(2, "Mark");
            studentlist.Add(3, "Neo");
            studentlist.Add(4, "Steven");
            studentlist.Add(5, "Clark");

            //Showing items
            for (int i = 0; i < studentlist.Count; i++)
            {
                Console.WriteLine("Keys : " + studentlist.Keys[i] + "\tValues : " + studentlist.Values[i]);
            }

            //Try to Insert Duplicate Keys
            try
            {
                Console.WriteLine("Try to Insert Duplicate Keys");
                studentlist.Add(5, "Mathew");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThis key already exist. " + ex.ToString());
            }

            //Change Keys Values
            studentlist[1] = "James Smith";

            //Search a Values
            if (studentlist.ContainsValue("Steven"))
            {
                Console.WriteLine("Items Found at Position : " + studentlist.IndexOfValue("Steven"));
            }

            //Traverse using foreach
            foreach (KeyValuePair<int, string> k in studentlist)
            {
                Console.WriteLine("Key : {0} - Value : {1}", k.Key, k.Value);
            }

            //Get the length of SortedList
            int len = studentlist.Count;
            Console.WriteLine("Length of StudentList is {0}", len.ToString());
        }

        public void GenFunction(T printvalue)
        {
            Console.WriteLine(printvalue);
        }

        public void GenDic()
        {
            //Adding Item 
            List<string> myList = new List<string>();
            myList.Add("Steven");
            myList.Add("Clark");
            myList.Add("Jack");

            //Printing Item
            foreach (string s in myList)
                Console.Write("\n" + s.ToString() + " ");

            //Sorting List
            myList.Sort();
            Console.WriteLine("\n \nAfter Sorting");
            foreach (string s in myList)
                Console.Write(s.ToString() + " ");

            //Removing Items
            myList.Remove("Clark");
            Console.WriteLine("\n \nRemoving Clark");
            foreach (string s in myList)
                Console.Write(s.ToString() + " ");

            //Inserting Item in the middle
            myList.Insert(2, "Mathew");
            Console.WriteLine("\n \nInserting Mathew at index position 2");
            foreach (string s in myList)
                Console.Write(s.ToString() + " ");
        }

    }
}
