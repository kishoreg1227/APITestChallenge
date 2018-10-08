using APITestChallenge.DataModels;
using APITestChallenge.Utilities;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace APITestChallenge.Tests
{
    [TestFixture]
    public class SampleTests : TestBase
    {
        [TestCase("weather", "q", "London")]
        [TestCase("weather", "q", "New York")]
        public void GetWeatherDataByCityNameTest(string endPoint, string key, string value)
        {
            //Arrange - Given
            RestManager.AddParameter(key, value);

            //Act - When
            RestManager.ExecuteRequest(endPoint, Method.GET);

            //Assert - Then
            Assert.AreEqual(HttpStatusCode.OK, RestManager.Status);
            var responseObjects = ToWeatherData(RestManager.ResponseContent);
            Assert.AreEqual(value, responseObjects.Name);
        }

        [TestCase("weather", "id", "2172797")]
        public void GetWeatherDataByCityIDTest(string endPoint, string key, string value)
        {
            //Arrange - Given
            RestManager.AddParameter(key, value);

            //Act - When
            RestManager.ExecuteRequest(endPoint, Method.GET);

            //Assert - Then
            Assert.AreEqual(HttpStatusCode.OK, RestManager.Status);
            var responseObjects = ToWeatherData(RestManager.ResponseContent);
            Assert.AreEqual(Convert.ToInt32(value), responseObjects.Id);
        }

        [TestCase("weather", 139, 35)]
        [TestCase("weather", 180, 78)]
        public void GetWeatherDataByGeoCoordinatesTest(string endPoint, int longitude, int latitude)
        {
            //Arrange - Given
            var queryStrings = new List<KeyValuePair<string, object>>();
            queryStrings.Add(new KeyValuePair<string, object>("lon", longitude));
            queryStrings.Add(new KeyValuePair<string, object>("lat", latitude));
            RestManager.AddQueryStrings(queryStrings);

            //Act - When
            RestManager.ExecuteRequest(endPoint, Method.GET);

            //Assert - Then
            Assert.AreEqual(HttpStatusCode.OK, RestManager.Status);
            var responseObjects = ToWeatherData(RestManager.ResponseContent);
            Assert.AreEqual(longitude, responseObjects.Coord.Lon);
            Assert.AreEqual(latitude, responseObjects.Coord.Lat);
        }

        #region private methods

        private WeatherData ToWeatherData(string responseJson)
        {
            return JsonHelpers.Deserialize<WeatherData>(RestManager.ResponseContent);
        }

        #endregion private methods
    }
}