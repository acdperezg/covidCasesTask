using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataAccess.Services.RapidApi.Model.Regions
{
    public class RegionDataRoot
    {
        [JsonProperty("data")]
        public List<RegionData> RegionsDataList { get; set; }
    }
}
