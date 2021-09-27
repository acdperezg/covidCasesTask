using CovidCases.BusinessRepository.ExportData.Csv;
using CovidCases.BusinessRepository.ExportData.Json;
using CovidCases.BusinessRepository.ExportData.Xml;

namespace CovidCases.BusinessRepository.ExportData
{
    public interface IExportRepository
    {
        IJsonExport JsonExport { get; }
        IXmlExport XmlExport { get; }
        ICsvExport CsvExport { get; }
    }
}
