using RS.TestTask.ConvertXMLToJsonObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RS.TestTask.ConvertXMLToJsonObject.Parse
{
    internal class SubstationLevel : VoltageLevelBase
    {
        protected List<SubstationModel> FindSubstation()
        {
           var ListModel=base.FindVoltageLevelGUID();
            for (int i=0; i < ListModel.Count; i++)
            {
                IEnumerable<XElement> address =
                from el in doc.Root.Elements(ns2+ "Substation")
                where (string)el.Attribute(ns3 + "about") == ListModel[i].SubstationGUID
                select el;          

                foreach (XElement el in address.Elements())
                {
                    if (el.Name == ns2 + "IdentifiedObject.name")
                    {
                        ListModel[i].SubstationName = el.Value;     //Находим каждое РУ и присваиваем каждому РУ название подстанции

                    }
                       
                }
            }
            return ListModel;
        }
    }
}
