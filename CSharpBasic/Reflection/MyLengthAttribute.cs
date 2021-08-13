using System;

namespace Reflection
{
    public class MyLengthAttribute : Attribute
    {
        public int FieldLength { get; set; }

        public MyLengthAttribute(int fieldLength)
        {
            FieldLength = fieldLength;
        }
    }
}
