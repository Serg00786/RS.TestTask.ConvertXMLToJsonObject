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
            for (int i=0; i<model.Substations.Count; i++)
            {
                string s = model.Substations[i].Generators.ToString();
                JObject rss = new JObject(
                        new JProperty(model.Substations[i].SubstationName,
                        new JObject(
                            new JProperty(model.Substations[i].Switchgear,
                            new JArray(
                                from p in model.Generators
                                where p.GeneratorGUID == s
                                select p.GeneratorName)))));                //Вывод конечного объекта в Консоль

                Console.WriteLine(rss.ToString());
            }
            

            
                          
                
        }
      
    }












    //string name = "Superstest";
    //Substation sub = new Substation
    //{
    //    SubstationName = model.Substations[0].SubstationName,
    //    switchGears = new SwitchGear
    //    {
    //        SwitchGearName = model.Substations[0].Switchgear,
    //        generatorName = new Generators
    //        {
    //            GeneratorsName = name
    //        }

    //    }
    //};


//    string[] nums2 = new string[4] { "First", "Second", "Third", "Fourth" };
//    var strs = new string[] { model.Substations[0].SubstationName, model.Substations[0].Switchgear, model.Generators[0].GeneratorName };
//    var strs1 = new string[] { model.Substations[0].SubstationName, model.Substations[0].Switchgear, model.Generators[0].GeneratorName };

//    JObject jo = new JObject();
//    JArray q = new JArray();
//    JArray jarray = new JArray();
//    //Object o = new JObject(new JProperty("data", jarray));

//    JObject parent = jo;
//    jarray.Add(parent);

//            var str = @"[1, 2, 3]";
//    var jArray1 = JArray.Parse(str);


//            for (int i = 0; i<strs.Length; i++)
//            {
//                var jo2 = new JObject();
//                if (i ==0)
//                {
//                    parent[strs[i]] = jo2;
//                    parent = jo2;
//                }
//                else if (i == 1)
//{
//    parent[strs[i]] = q;
//    q.Add(parent);
//}
//else
//{

//    for (int j = 1; j < 3; j++)
//    {
//        q[nums2[j]] = "";
//        //j[0] =model.Generators[1].GeneratorName;
//    }



//}


//            }

//            // Your final json object is jo
//            Console.WriteLine(jo);

//// string version
//string json = (jo.ToString());  // or jo.ToString(Formatting.None)

//var data = JsonConvert.SerializeObject(sub, Formatting.Indented);


public class Generators
    {
        //[JsonProperty(PropertyName = "GeneratorsName")]
        public string GeneratorsName { get; set; }
    }

    public class SwitchGear
    {
        //[JsonProperty(PropertyName = "SwitchGearName")]
        public string SwitchGearName { get; set; }
        public Generators generatorName { get; set; }
    }
    public class Substation
    {
        //[JsonProperty(PropertyName = "SubstationName")]
        public string SubstationName { get; set; }
        //[JsonProperty(PropertyName = "switchGears")]
        public SwitchGear switchGears { get; set; }

        //[JsonProperty(PropertyName = "Generators")]
        //public List<Generators> Generators { get; set; }
    }

    public class RootObj
    {
        public Substation substation { get; set; }
    }






}








//var obj = new
//{
//    name = "flare",
//    children = new[] {
//        new {
//            name = "analytics",
//            children = new dynamic [] {
//                new {
//                    name = "cluster",
//                    children = new dynamic [] {
//                        new { name = "AgglomerativeCluster", size = 3938},
//                        new { name = "MergeEdge", size = 743},
//                    }
//                },
//                new {
//                    name = "graph",
//                    children = new dynamic [] {
//                        new { name = "BetweennessCentrality", size = 3534},
//                        new { name = "SpanningTree", size = 3416},
//                    }
//                },
//                new {
//                    name = "optimization",
//                    children = new dynamic [] {
//                        new { name = "AspectRatioBanker", size = 7074},
//                    }
//                },
//            }
//        },
//        new {
//            name = "animate",
//            children = new dynamic [] {
//                new { name = "Easing", size = 17010},
//                new { name = "FunctionSequence", size = 5842},
//                new {
//                    name = "interpolate",
//                    children = new [] {
//                    new { name = "ArrayInterpolator",  size = 1983},
//                    new { name = "RectangleInterpolator", size = 2042}
//                    }
//                },
//                new { name = "ISchedulable", size = 1041},
//                new { name = "Tween", size = 6006},
//            }
//        },
//    }
//};
//var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
