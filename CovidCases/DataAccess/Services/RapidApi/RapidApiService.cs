using Configuration.RapidApi;
using DataAccess.Services.RapidApi.Model.Regions;
using DataAccess.Services.RapidApi.Model.Reports;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using static System.String;

namespace DataAccess.Services.RapidApi
{
    public class RapidApiService : IRapidApiService
    {
        #region Private Fields
        private readonly IRapidApiConfiguration _rapidApiConfiguration;
        #endregion

        #region Constructors
        public RapidApiService(IRapidApiConfiguration rapidApiConfiguration)
        {
            _rapidApiConfiguration = rapidApiConfiguration;
        }
        #endregion

        #region Public Methods
        public async Task<RegionDataRoot> GetRegions()
        {
            string url = $"{_rapidApiConfiguration.GetBaseUrl}/{_rapidApiConfiguration.GetRegionUrl}";
            return await Get<RegionDataRoot>(url);
        }

        public async Task<RapidApiRoot> GetReports(string regionName)
        {
            string url = $"{_rapidApiConfiguration.GetBaseUrl}/{_rapidApiConfiguration.GetReportUrl}";
            bool hasNoRegion = IsNullOrEmpty(regionName);
            return await Get<RapidApiRoot>(hasNoRegion ? url : $"{url}?region_name={regionName}");
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Permorms a GET request to the given URL and converts to the specified object T the response
        /// </summary>
        /// <typeparam name="T">Object type to convert to</typeparam>
        /// <param name="url">Url to send the request</param>
        /// <returns>The response of the request converted to the specified T object</returns>
        private async Task<T> Get<T>(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", _rapidApiConfiguration.GetHostHeaderValue);
            request.AddHeader("x-rapidapi-key", _rapidApiConfiguration.GetKeyHeaderValue);
            var response = await client.ExecuteAsync<T>(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        #endregion
    }
}
