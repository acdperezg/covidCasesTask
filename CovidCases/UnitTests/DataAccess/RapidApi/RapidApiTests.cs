using Configuration.RapidApi;
using DataAccess.Services.RapidApi;
using static System.String;
using Xunit;

namespace UnitTests.DataAccess.RapidApi
{
    public class RapidApiTests
    {
        [Theory]
        [InlineData("regions")]
        [InlineData("reports")]
        public async void ApiPathValids(string path)
        {
            //Arrange
            IRapidApiConfiguration apiConfigurationMock = CreateApiConfigurationMock(path);
            RapidApiService api = new RapidApiService(apiConfigurationMock);

            //Act
            var actual = await api.GetRegions();

            //Assert
            Assert.True(actual != null);
        }

        [Theory]
        [InlineData("US")]
        [InlineData("Japan")]
        public async void GetReports(string regionName)
        {
            //Arrange
            IRapidApiConfiguration apiConfigurationMock = CreateApiConfigurationMock("reports");

            RapidApiService api = new RapidApiService(apiConfigurationMock);

            //Act
            var actual = await api.GetReports(regionName);

            //Assert
            Assert.True(actual != null);

            if (!IsNullOrEmpty(regionName))
            {
                foreach (var i in actual.RapidApiRegionDataList)
                {
                    Assert.Equal(regionName, i.Region.Name);
                }
            }
        }


        #region Auxiliary
        private IRapidApiConfiguration CreateApiConfigurationMock(string path)
        {
            var configApiMock = new Moq.Mock<IRapidApiConfiguration>();
            configApiMock.Setup(x => x.GetBaseUrl).Returns("https://covid-19-statistics.p.rapidapi.com");
            configApiMock.Setup(x => x.GetReportUrl).Returns(path);
            configApiMock.Setup(x => x.GetHostHeaderValue).Returns("covid-19-statistics.p.rapidapi.com");
            configApiMock.Setup(x => x.GetKeyHeaderValue).Returns("a56b2240b3msh8aa50e8e0cc8b20p13cc2cjsn51ea9ea70344");
            return configApiMock.Object;
        }
        #endregion
    }
}
