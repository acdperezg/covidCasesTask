using Newtonsoft.Json;

namespace DataAccess.Services.RapidApi.Model.Reports
{
    public class RapidApiData
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }
        
        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }

        [JsonProperty("confirmed_diff")]
        public int ConfirmedDiff { get; set; }

        [JsonProperty("deaths_diff")]
        public int DeathsDiff { get; set; }

        [JsonProperty("recovered_diff")]
        public int RecoveredDiff { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("active_diff")]
        public int ActiveDiff { get; set; }

        [JsonProperty("fatality_rate")]
        public double FatalityRate { get; set; }

        public Region Region { get; set; }
    }
}
