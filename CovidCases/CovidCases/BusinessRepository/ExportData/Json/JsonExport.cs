using System.Text;

namespace CovidCases.BusinessRepository.ExportData.Json
{
    public class JsonExport : IJsonExport
    {
        public byte[] ExportReport(string jsonList)
        {
            return Encoding.UTF8.GetBytes(jsonList);
        }
    }
}
