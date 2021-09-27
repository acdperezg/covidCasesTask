using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataAccess.Services.RapidApi.Model.Reports
{
    public class RapidApiRoot
    {
        [JsonProperty("data")]
        public List<RapidApiData> RapidApiRegionDataList { get; set; }
    }
}
