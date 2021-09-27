using CovidCases;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UnitTests.BusinessRepository
{
    public class IntegrationTest
    {
        protected readonly WebApplicationFactory<Startup> _factory;
        public IntegrationTest()
        {
            _factory = new WebApplicationFactory<Startup>();
        }
    }
}
