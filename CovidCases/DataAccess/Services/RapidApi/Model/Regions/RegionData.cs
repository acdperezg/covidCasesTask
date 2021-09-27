using Newtonsoft.Json;

namespace DataAccess.Services.RapidApi.Model.Regions
{
    public class RegionData
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
