using CovidCases.BusinessRepository.ExportData.Csv;
using CovidCases.BusinessRepository.ExportData.Json;
using CovidCases.BusinessRepository.ExportData.Xml;

namespace CovidCases.BusinessRepository.ExportData
{
    public class ExportRepository : IExportRepository
    {
        #region Private Fields

        private readonly IJsonExport _jsonExport;

        private readonly IXmlExport _xmlExport;

        private readonly ICsvExport _csvExport;

        #endregion

        #region Constructors

        public ExportRepository(IJsonExport jsonExport, IXmlExport xmlExport, ICsvExport csvExport)
        {
            _jsonExport = jsonExport;
            _xmlExport = xmlExport;
            _csvExport = csvExport;
        }

        #endregion

        #region Public Methods
        public IJsonExport JsonExport => _jsonExport;

        public IXmlExport XmlExport => _xmlExport;

        public ICsvExport CsvExport => _csvExport;

        #endregion
    }
}
