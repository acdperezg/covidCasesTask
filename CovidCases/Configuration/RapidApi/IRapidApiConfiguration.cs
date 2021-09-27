 using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.RapidApi
{
    public interface IRapidApiConfiguration
    {
        string GetBaseUrl { get; }
        string GetReportUrl { get; }
        string GetRegionUrl { get; }
        string GetHostHeaderValue { get; }
        string GetKeyHeaderValue { get; }
    }
}
