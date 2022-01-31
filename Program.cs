using Autofac;
using RS.TestTask.ConvertXMLToJsonObject.Abstraction;
using RS.TestTask.ConvertXMLToJsonObject.CreateJson;
using RS.TestTask.ConvertXMLToJsonObject.Interfaces;
using RS.TestTask.ConvertXMLToJsonObject.Parse;
using System;

namespace RS.TestTask.ConvertXMLToJsonObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Converter con = new XMLToJsonConvertion("XMLToJson");
            Product product = con.Create();

            //Интересно то, что количество генераторов
            //оказалось меньше РУ и подстанций


            //В Классе Parse/VoltageLevelBase необъодимо указать путь где лежим Example.xml



            Console.ReadLine();

        }
    }
}
