namespace CovidCases.Models.Responses.Reports
{
    /// <summary>
    /// Contains the data for the covid information for a Region
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public class ReportsResponse
    {
        /// <summary>
        /// Name of the Region or Province
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Total of confirmed cases by Covid
        /// </summary>
        public int Cases { get; set; }

        /// <summary>
        /// Total of deaths by Covid
        /// </summary>
        public int Deaths { get; set; }
    }
}
