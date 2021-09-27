using DataAccess.Services.RapidApi.Model.Regions;
using DataAccess.Services.RapidApi.Model.Reports;
using System.Threading.Tasks;

namespace DataAccess.Services.RapidApi
{
    public interface IRapidApiService
    {
        Task<RapidApiRoot> GetReports(string regionName);
        Task<RegionDataRoot> GetRegions();
    }
}
