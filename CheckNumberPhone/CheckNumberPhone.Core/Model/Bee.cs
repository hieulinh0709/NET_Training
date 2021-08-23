using System.Collections.Generic;

namespace FindBeeNumbers.Core.Model
{
    public class Bee
    {
        public int Limit { get; set; }
        public List<Provider> Providers { get; set; }
        public string[] TabooNumbers { get; set; }
        public string[] NiceNumbers { get; set; }
        public List<SumOfNumbers> SumOfNumbers { get; set; }
    }
}
