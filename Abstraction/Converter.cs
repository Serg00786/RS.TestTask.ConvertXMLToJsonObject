using Autofac;
using RS.TestTask.ConvertXMLToJsonObject.CreateJson;
using RS.TestTask.ConvertXMLToJsonObject.Interfaces;
using RS.TestTask.ConvertXMLToJsonObject.Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.TestTask.ConvertXMLToJsonObject.Abstraction
{
    abstract class Converter
    {
        public string Name { get; set; }

        public Converter(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public Product Create();
    }
}
