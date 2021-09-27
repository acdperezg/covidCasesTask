using CovidCases.Models.Responses.Reports;
using System.Collections.Generic;

namespace CovidCases.Models.Responses.RapidApi.Reports
{
    /// <summary>
    /// Contains the list of cases due to Covid
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public class ReportsRootResponse : BaseResponse
    {
        /// <summary>
        /// List of regions or Provinces
        /// </summary>
        public List<ReportsResponse> ReportsDataList { get; set; }

        /// <summary>
        /// Indicates if the results are filtered by any Region
        /// </summary>
        public bool IsFiltered { get; set; }
    }
}
