using Newtonsoft.Json.Linq;
using RS.TestTask.ConvertXMLToJsonObject.Interfaces;
using RS.TestTask.ConvertXMLToJsonObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RS.TestTask.ConvertXMLToJsonObject.CreateJson
{
    internal class CreateJsonObject : ICreateJsonObject
    {
        public void CreateFile(XMLParseModel model)
        {
            JObject jo = new JObject();
            for (int i = 0; i < model.Substations.Count; i++)
            {
                string s = model.Substations[i].Generators.ToString();
                JObject rss = new JObject(
                        new JProperty(model.Substations[i].SubstationName,
                        new JObject(
                            new JProperty(model.Substations[i].Switchgear,
                            new JArray(
                                from p in model.Generators
                                where p.GeneratorGUID == s
                                select p.GeneratorName)))));

                Console.WriteLine(rss.ToString());       //Вывод конечного объекта в Консоль

                    //Merge all in one Object

                jo.Merge(rss, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union 
                });               
            }
            

        }

    }
}