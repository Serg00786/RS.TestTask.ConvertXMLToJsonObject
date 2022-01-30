using System;
using System.Collections.Generic;
using System.Text;

namespace RS.TestTask.ConvertXMLToJsonObject.Abstraction
{
    // создаёт какой-то другой объект,  для другого преобразования
    class OtherConvertion : Converter
    {
        public OtherConvertion(string n) : base(n)
        { }

        public override Product Create()
        {
            return new OtherObject();
        }
    }
}
