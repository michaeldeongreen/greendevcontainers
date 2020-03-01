using NUnit.Framework;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using greendevcontainers.webapi;
using System.Net;

namespace greendevcontainers.integration.tests
{
    [TestFixture]
    public class WeatherForecastTests
    {
        private HttpClient _client;
        private const string _baseAddress = "https://localhost:5001";

        [OneTimeSetUp]
        public void Init()
        {
            _client = new HttpClient() 
            {
                BaseAddress = new Uri(_baseAddress)
            };
        }

        [Test]
        public async Task Weatherforecast_Get_Test()
        {
            // given
            var response = await _client.GetAsync("/api/weatherforecast");            
            // when
            var weatherforecasts = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}