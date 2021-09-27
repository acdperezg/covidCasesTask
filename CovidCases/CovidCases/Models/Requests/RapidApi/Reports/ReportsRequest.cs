namespace CovidCases.Models.Requests.RapidApi.Reports
{
    /// <summary>
    /// Values to perform a search of covid reports
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public class ReportsRequest
    {
        /// <summary>
        /// Name of the region to look for
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Total of results to visualice
        /// </summary>
        public int RegionResults { get; set; }
    }
}
