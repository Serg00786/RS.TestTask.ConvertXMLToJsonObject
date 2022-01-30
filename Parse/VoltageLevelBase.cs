using RS.TestTask.ConvertXMLToJsonObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RS.TestTask.ConvertXMLToJsonObject.Parse
{
    internal class VoltageLevelBase
    {
        protected XNamespace ns2 = "http://iec.ch/TC57/2014/CIM-schema-cim16#";
        protected XNamespace ns3 = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
        protected XDocument doc= XDocument.Load("C:\\Example.xml");

        protected List<SubstationModel> FindVoltageLevelGUID()
        {
            List<SubstationModel> SubList = new List<SubstationModel>();
            SubstationModel SubModel = new SubstationModel();
          
            foreach (XElement el in doc.Root.Elements())
            {
                if(el.Name== ns2 + "VoltageLevel")                      //Находим VoltageLevel
                {
                    
                    SubModel=FindVoltageLevelSubstationGUID(el);                
                    SubModel.Generators = el.Attribute(ns3 + "about").Value;    //Находим привязку РУ к генератору
                    SubList.Add(SubModel);

                }
            }
            return SubList;
        }

        private SubstationModel FindVoltageLevelSubstationGUID(XElement address)
        {

            SubstationModel substation = new SubstationModel();

            foreach (XElement el in address.Elements())
            {
                if (el.Name == ns2 + "IdentifiedObject.name")
                {
                    substation.Switchgear = el.Value;               //Находим имя объекта
                }
                if(el.Name== ns2 + "VoltageLevel.Substation")
                {
                    substation.SubstationGUID = el.Attribute(ns3 + "resource").Value;       // Находим привязку РУ к подстанции
                }
            }
            return substation;
            
        }
    }
}
