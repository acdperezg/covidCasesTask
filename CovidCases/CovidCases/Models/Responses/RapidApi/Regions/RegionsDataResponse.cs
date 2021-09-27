namespace CovidCases.Models.Responses.RapidApi.Regions
{
    /// <summary>
    /// Contains the response of the region list
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public class RegionsDataResponse
    {
        /// <summary>
        /// Iso name of the Region
        /// </summary>
        public string Iso { get; set; }

        /// <summary>
        /// Name of the Region
        /// </summary>
        public string Name { get; set; }
    }
}
