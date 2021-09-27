using System.Collections.Generic;

namespace CovidCases.Models.Responses.RapidApi.Regions
{
    /// <summary>
    /// Contains the list of regions retrieved by the Covid service
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public class RegionsDataRootResponse : BaseResponse
    {
        /// <summary>
        /// List of regions
        /// </summary>
        public List<RegionsDataResponse> RegionsListData { get; set; }
    }
}
