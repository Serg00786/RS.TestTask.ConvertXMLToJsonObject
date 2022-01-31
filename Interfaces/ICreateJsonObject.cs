using RS.TestTask.ConvertXMLToJsonObject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.TestTask.ConvertXMLToJsonObject.Interfaces
{
    internal interface ICreateJsonObject
    {
        void CreateFile(XMLParseModel model);
    }
}
