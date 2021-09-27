using CovidCases.Models.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;

namespace CovidCases.BusinessRepository.ExportData.ExportBusiness
{
    /// <summary>
    /// Implements the business logic to export the covid information
    /// </summary>
    /// <remarks>Author: Dariel Pérez</remarks>
    public class ExportBusinessRepository : IExportBusinessRepository
    {

        #region Private Fields
        /// <summary>
        /// Accesses to the available repositories to download the information
        /// </summary>
        private readonly IExportRepository _mainRepository;
        #endregion

        #region Constructor
        
        public ExportBusinessRepository(IExportRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the by array of a json object after converted to the object specified by the format parameter
        /// </summary>
        /// <param name="dataList">Json object list</param>
        /// <param name="format">Format to convert. Can be JSON, XML and CSV</param>
        /// <returns>THe byte array of the converted Json object</returns>
        public FileContentResult GetByteArray(string dataList, string format)
        {
            FileContentResult result = null;
            string formatedList = AddRootElements(dataList);

            switch (format)
            {
                case MessagesConstants.EXPORT_FORMAT_JSON:
                    {
                        byte[] bytes = _mainRepository.JsonExport.ExportReport(dataList);
                        result = new FileContentResult(bytes, MediaTypeNames.Application.Json)
                        {
                            FileDownloadName = $"ReportsData_{DateTime.Now.Ticks}.json"
                        };
                        break;
                    }
                case MessagesConstants.EXPORT_FORMAT_XML:
                    {
                        byte[] bytes = _mainRepository.XmlExport.ExportReport(formatedList);
                        result = new FileContentResult(bytes, MediaTypeNames.Application.Xml)
                        {
                            FileDownloadName = $"ReportsData_{DateTime.Now.Ticks}.xml"
                        };
                        break;
                    }
                case MessagesConstants.EXPORT_FORMAT_CSV:
                    {
                        byte[] bytes = _mainRepository.CsvExport.ExportReport(dataList);
                        result = new FileContentResult(bytes, "text/csv")
                        {
                            FileDownloadName = $"ReportsData_{DateTime.Now.Ticks}.csv"
                        };
                        break;
                    }
                default: break;
            }

            return result;
        }
        #endregion

        #region Auxiliary

        /// <summary>
        /// Adds to a json the root elements
        /// </summary>
        /// <param name="dataList">Json string to append root elements</param>
        /// <returns>The Json provided by parameter with the root nodes</returns>
        private string AddRootElements(string dataList)
        {
            string prefix = "{ \"regionList\": { \"region\": ";
            string sufix = "}}";
            return $"{prefix}{dataList}{sufix}";
        }
        #endregion

    }
}
