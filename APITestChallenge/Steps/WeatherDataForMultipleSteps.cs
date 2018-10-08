using APITestChallenge.DataModels;
using APITestChallenge.Tests;
using APITestChallenge.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace APITestChallenge.Steps
{
    [Binding]
    public sealed class WeatherDataForMultipleSteps : BDDTestBase
    {
        [Given(@"I set the following bounding box parameters (.*),(.*),(.*),(.*),(.*)")]
        public void GivenISetTheFollowingBoundingBoxParameters(double lonleft, double latbottom,
            double lonright, double lattop, double zoom)
        {
            //Arrange
            string value = $"{lonleft},{latbottom},{lonright},{lattop},{zoom}";
            RestManager.AddQueryStrings("bbox", value);
            Console.WriteLine("TEST");
        }

        [When(@"I execute the API call on '(.*)' the endpoint")]
        public void WhenIExecuteTheAPICallOnTheEndpoint(string endPoint)
        {
            //Act
            RestManager.ExecuteRequest(endPoint, Method.GET);
        }

        [Then(@"following should be available in the response content (.*)")]
        public void ThenFollowingShouldBeAvailableInTheResponseContent(string result)
        {
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, RestManager.Status);
            var responseObjects = JsonHelpers.Deserialize<CitiesInRectangleZone>(RestManager.ResponseContent);
            Assert.AreEqual(15, responseObjects.List.Count);
        }
    }
}