using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.BusinessRepository
{
    public class BusinessRepositoryTest : IntegrationTest
    {
        private const string LOCAL_HOST_URL = "https://localhost:44334/";

        [Theory]
        [InlineData("GetRegions")]
        public async Task Get_RegionsReturnSuccess(string url)
        {
            
            //Arrange
            var client = _factory.CreateClient();
            client.BaseAddress = new Uri(LOCAL_HOST_URL);

            //Act 
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }


        [Fact]
        public async Task Get_ReportsReturnSuccess()
        {

            //Arrange
            var client = _factory.CreateClient();
            client.BaseAddress = new Uri(LOCAL_HOST_URL);

            //Act 
            var response = await client.PostAsync("home/GetReports", null);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(15)]
        public async Task Get_Reports_Returns_Expected_Ammount(int totalRecords)
        {
            // Arrange
            var client = _factory.CreateClient();
            client.BaseAddress = new Uri(LOCAL_HOST_URL);
            var url = $"GetReportsData?RegionName=US&RegionResults={totalRecords}";

            //Act
            var response = await client.PostAsync(url, null);
            var contentRead = await response.Content.ReadAsStringAsync();

            int count = contentRead.Split("name").Length - 1;

            //Assert
            if (totalRecords == 0)
            {
                Assert.Equal(10, count);
            }
            else
            {
                Assert.Equal(totalRecords, count);
            }
        }
    }
}
