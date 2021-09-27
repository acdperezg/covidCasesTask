using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace CovidCases.BusinessRepository.ExportData.Xml
{
    public class XmlExport : IXmlExport
    {
        public byte[] ExportReport(string jsonList)
        {
            XmlDocument document = JsonConvert.DeserializeXmlNode(jsonList);
            return Encoding.Default.GetBytes(document.OuterXml);
        }
    }
}
