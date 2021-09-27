using CovidCases.Models.Requests.RapidApi.Reports;
using CovidCases.Models.Responses.RapidApi.Regions;
using CovidCases.Models.Responses.RapidApi.Reports;
using System.Threading.Tasks;

namespace CovidCases.BusinessRepository.RapidApi
{
    public interface IRapidApiBusinessRepository
    {
        Task<ReportsRootResponse> GetReports(ReportsRequest reportRequest);
        Task<RegionsDataRootResponse> GetRegions();
    }
}
