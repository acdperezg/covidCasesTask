using CovidCases.BusinessRepository.ExportData.ExportBusiness;
using CovidCases.BusinessRepository.RapidApi;
using CovidCases.Models;
using CovidCases.Models.Requests.RapidApi.Reports;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.String;

namespace CovidCases.Controllers
{
    /// <summary>
    /// Main controller of the application
    /// </summary>
    /// <remarks>Author: Dariel Pérez</remarks>
    public class HomeController : Controller
    {
        #region Private Fields
        /// <summary>
        /// Accesess to the business logic for calling the API for covid information
        /// </summary>
        private readonly IRapidApiBusinessRepository _rapidApiBusinessRepository;

        /// <summary>
        /// Accesess to the business logic for calling the API for export the information
        /// </summary>
        private readonly IExportBusinessRepository _exportBusinessRepository;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for initialice the private fields of the class
        /// </summary>
        /// <param name="rapidApiBusinessRepository">Accesess to the business logic for calling the API for covid information</param>
        /// <param name="exportBusinessRepository">Accesess to the business logic for calling the API for export the information</param>
        public HomeController(IRapidApiBusinessRepository rapidApiBusinessRepository, IExportBusinessRepository exportBusinessRepository)
        {
            _rapidApiBusinessRepository = rapidApiBusinessRepository;
            _exportBusinessRepository = exportBusinessRepository;
        }

        #endregion

        #region Public Methods
        [HttpGet]
        [Route("GetRegions")]
        public async Task<IActionResult> GetRegions()
        {
            var result = await _rapidApiBusinessRepository.GetRegions();

            return Json(result);
        }

        [HttpPost]
        [Route("GetReportsData")]
        public async Task<IActionResult> GetReportsData(ReportsRequest requestReport)
        {
            var result = await _rapidApiBusinessRepository.GetReports(requestReport);
            result.IsFiltered = !IsNullOrEmpty(requestReport.RegionName);

            return Json(result); ;
        }

        [HttpPost]
        public async Task<IActionResult> GetReports(ReportsRequest requestReport)
        {
            var result = await _rapidApiBusinessRepository.GetReports(requestReport);
            result.IsFiltered = !IsNullOrEmpty(requestReport.RegionName);

            if (result.Message != "Success")
            {
                return BadRequest(result);
            }

            return PartialView("_RegionsPartial", result);
        }

        [HttpGet]
        public FileResult ExportDataToFile(string list, string format)
        {
            FileContentResult result = _exportBusinessRepository.GetByteArray(list, format);

            return result;
        }

        public async Task<IActionResult> Index()
        {

            var regionsData = await _rapidApiBusinessRepository.GetReports(new ReportsRequest
            {
                RegionName = Empty,
                RegionResults = 0
            });

            var regionNames = await _rapidApiBusinessRepository.GetRegions();
            regionNames.RegionsListData.Insert(0, new Models.Responses.RapidApi.Regions.RegionsDataResponse { Iso = "0", Name = "Regions" });

            ViewBag.regionNames = regionNames;

            return View(regionsData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
