using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class ReflectionInformation
    {
        private int _id;
        private string _name;

        public ReflectionInformation()
        {

        }

        public ReflectionInformation(int id)
        {
            Id = id;
        }

        public ReflectionInformation(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Write()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
        }

        public void Write(string name)
        {
            Console.WriteLine("Name: " + name);
        }
    }
}
