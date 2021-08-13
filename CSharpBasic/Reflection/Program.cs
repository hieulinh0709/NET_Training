using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var reflection = new ReflectionCSharp();
            //reflection.Run();
            reflection.ValidateReflection();

            Console.ReadKey();
        }
    }

    public class ReflectionCSharp
    {

        public void ValidateReflection()
        {
            var myDataModelInstance = new MyDataModel()
            {
                PropertyA = "12",
                PropertyB = "12345"
            };

            foreach (var prop in typeof(MyDataModel).GetProperties())
            {

                //get fieldlength attribute of MyDataModel
                var fieldLength = ((MyLengthAttribute)prop.GetCustomAttribute(typeof(MyLengthAttribute)))?.FieldLength;

                var value = prop.GetValue(myDataModelInstance)?.ToString();

                if (value != null && value.Length > fieldLength)
                {
                    Console.WriteLine($"{prop.Name} has an invalid value \"{value}\" with length of {value.Length} when max length is {fieldLength}.");
                }
            }
        }

        public void Run()
        {
            var reflectionInfo = new ReflectionInformation();
            var type = reflectionInfo.GetType();

            //  Một tham số
            var firstReflection = (ReflectionInformation)Activator.CreateInstance(type, new object[] { 10 });
            //  Hai tham số
            var secondReflection = (ReflectionInformation)Activator.CreateInstance(type, new object[] { 10, "Name" });  

            firstReflection.Write();    //  Output: Id: 10. Name:
            secondReflection.Write();   //  Output: Id: 10. Name: Name
        }

    }
}
