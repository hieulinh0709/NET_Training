namespace Reflection
{
    public class MyDataModel
    {
        [MyLength(3)] //Customize attribute
        public string PropertyA { get; set; }
        [MyLength(4)]
        public string PropertyB { get; set; }
    }
}
