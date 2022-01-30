using RS.TestTask.ConvertXMLToJsonObject.Interfaces;
using RS.TestTask.ConvertXMLToJsonObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RS.TestTask.ConvertXMLToJsonObject.Parse
{
    internal sealed class GenerateLevelcs : SubstationLevel, IGenerateLevel
    {
        public XMLParseModel FindGenerators()
        {
            var SubstationList = base.FindSubstation();
            List<GeneratorModel> ListGenerators = new List<GeneratorModel>();
            GeneratorModel generatorModel = new GeneratorModel();
            XMLParseModel xMLParseModel = new XMLParseModel();

            string GeneratorID = "";
            string GeneratorNames;

                IEnumerable<XElement> address =                             //Находим все элементы SynchronousMachine
                from el in doc.Root.Elements(ns2 + "SynchronousMachine")
                select el;

                foreach (XElement el in address.Elements())
                {
                    if (el.Name == ns2 + "Equipment.EquipmentContainer")
                    {
                        GeneratorID = (string)(el.Attribute(ns3 + "resource"));     //Находим вложенный EquipmentContainer
                    }
                   else if (el.Name == ns2 + "IdentifiedObject.name")
                    {
                        GeneratorNames = el.Value;                          //Определяем имя генератора

                        if(!string.IsNullOrEmpty(GeneratorID) && !string.IsNullOrEmpty(GeneratorNames))
                        {
                            ListGenerators.Add(new GeneratorModel {GeneratorGUID=GeneratorID, GeneratorName=GeneratorNames });
                            GeneratorID = string.Empty;         //Записываем в лист когда оба объекта прочитаны в одном "SynchronousMachine"
                        GeneratorNames = string.Empty;  
                        }
                    }
                }

            xMLParseModel.Substations = SubstationList;
            xMLParseModel.Generators = ListGenerators;

            return xMLParseModel;

        }
    }
}
