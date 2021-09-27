using CovidCases.Models.Helper;
using CovidCases.Models.Requests.RapidApi.Reports;
using CovidCases.Models.Responses.RapidApi.Regions;
using CovidCases.Models.Responses.RapidApi.Reports;
using CovidCases.Models.Responses.Reports;
using DataAccess.Services.RapidApi;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.String;

namespace CovidCases.BusinessRepository.RapidApi
{
    /// <summary>
    /// Implements the business logic to access the API
    /// </summary>
    /// <remarks>Author: Dariel Pérez</remarks>
    public class RapidApiBusinessRepository : IRapidApiBusinessRepository
    {
        #region Private Fields
        private readonly IRapidApiService _rapidApiService;
        private readonly ILogger<RapidApiBusinessRepository> _logger;
        #endregion

        #region Constructors
        public RapidApiBusinessRepository(ILogger<RapidApiBusinessRepository> logger, IRapidApiService rapidApiConfiguration)
        {
            _logger = logger;
            _rapidApiService = rapidApiConfiguration;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get the region list
        /// </summary>
        /// <returns>Region list</returns>
        public async Task<RegionsDataRootResponse> GetRegions()
        {
            try
            {
                RegionsDataRootResponse result = new RegionsDataRootResponse();
                var response = await _rapidApiService.GetRegions();

                result.Message = MessagesConstants.SUCCESS_MESSAGE;
                result.Code = MessagesConstants.SUCCESS_CODE;
                result.RegionsListData = response.RegionsDataList.Select(x => new RegionsDataResponse()
                {
                    Iso = x.Iso,
                    Name = x.Name
                }).OrderBy(y => y.Name).ToList();

                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new RegionsDataRootResponse()
                {
                    Message = MessagesConstants.ERROR_MESSAGE_REGION,
                    Code = MessagesConstants.ERROR_CODE,
                    RegionsListData = new List<RegionsDataResponse>()
                };
            }
        }

        /// <summary>
        /// Gets the COvid information specified by parameters
        /// </summary>
        /// <param name="reportRequest">Contains the region name to look for and the amount of records desired.
        /// If no amount is provided, by default returns records</param>
        /// <returns>Covid information list</returns>
        public async Task<ReportsRootResponse> GetReports(ReportsRequest reportRequest)
        {
            try
            {
                ReportsRootResponse result = new ReportsRootResponse();
                bool findByRegionName = !IsNullOrEmpty(reportRequest.RegionName);
                var response = await _rapidApiService.GetReports(reportRequest.RegionName);

                var orderedList = response.RapidApiRegionDataList.OrderByDescending(x => x.Confirmed);

                result.Message = MessagesConstants.SUCCESS_MESSAGE;
                result.Code = MessagesConstants.SUCCESS_CODE;
                result.ReportsDataList = orderedList.Select(x => new ReportsResponse()
                {
                    Deaths = x.Deaths,
                    Cases = x.Confirmed,
                    Name = findByRegionName ? IsNullOrEmpty(x.Region.Province) ? MessagesConstants.NO_PROVINCE_NAME : x.Region.Province : x.Region.Name
                }).Take(reportRequest.RegionResults == 0 ? MessagesConstants.RESULT_COUNT : reportRequest.RegionResults).ToList();

                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ReportsRootResponse()
                {
                    Message = MessagesConstants.ERROR_MESSAGE_DATA,
                    Code = MessagesConstants.ERROR_CODE,
                    ReportsDataList = new List<ReportsResponse>()
                };
            }
        }

        #endregion

        #region Auxiliary
        private void LogError(Exception ex)
        {
            _logger.LogError(ex.ToString());
        }
        #endregion
    }
}
