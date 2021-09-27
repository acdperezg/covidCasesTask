using Microsoft.Extensions.Configuration;
using System;

namespace Configuration.RapidApi
{
    public class RapidApiConfiguration : IRapidApiConfiguration
    {
        public string GetBaseUrl { get; private set; }
        public string GetReportUrl { get; private set; }
        public string GetRegionUrl { get; private set; }
        public string GetHostHeaderValue { get; private set; }
        public string GetKeyHeaderValue { get; private set; }

        public RapidApiConfiguration(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            LoadConfiguration(configuration);
        }

        private void LoadConfiguration(IConfiguration configuration)
        {
            GetBaseUrl = configuration.GetValue<string>("RapidApi:BaseUrl");
            GetReportUrl = configuration.GetValue<string>("RapidApi:Reports");
            GetRegionUrl = configuration.GetValue<string>("RapidApi:Region");
            GetHostHeaderValue = configuration.GetValue<string>("RapidApi:HostHeaderValue");
            GetKeyHeaderValue = configuration.GetValue<string>("RapidApi:HostKeyValue");
        }
    }
}
