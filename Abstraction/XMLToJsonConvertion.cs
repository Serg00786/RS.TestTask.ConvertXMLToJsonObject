using Autofac;
using RS.TestTask.ConvertXMLToJsonObject.CreateJson;
using RS.TestTask.ConvertXMLToJsonObject.Interfaces;
using RS.TestTask.ConvertXMLToJsonObject.Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.TestTask.ConvertXMLToJsonObject.Abstraction
{
    //Создает JSON объект
    class XMLToJsonConvertion : Converter
    {
        public XMLToJsonConvertion(string n) : base(n)
        { }

        public override Product Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GenerateLevelcs>().As<IGenerateLevel>();
            builder.RegisterType<CreateJsonObject>().As<ICreateJsonObject>();
            IContainer container = builder.Build();
            IGenerateLevel Parseservice = container.Resolve<IGenerateLevel>();
            ICreateJsonObject createJsonObject = container.Resolve<ICreateJsonObject>();

            var Result = Parseservice.FindGenerators();
            createJsonObject.CreateFile(Result);

            return new JsonObject();
        }
    }
}
