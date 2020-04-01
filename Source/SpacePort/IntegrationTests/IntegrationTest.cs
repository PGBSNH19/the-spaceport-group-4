using RestSharp;
using SpacePort;
using System;
using System.Collections.Generic;
using Xunit;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace IntegrationTests
{
    public class IntegrationTest
    {
        [Theory]
        [InlineData("Luke SKYWALKER")]
        [InlineData("Micael skYwalker")]
        [InlineData("bB8")]
        [InlineData("Beru Whitesun Lars")]
        public void GetTravelerDataAsunc_SearchByName_ExpectJObjectReturned(string name)
        {
            StarWarsApi api = new StarWarsApi();

            JObject jObjectReturned = api.GetTravelerDataAsync(name.ToLower()).Result;

            Assert.IsType<JObject>(jObjectReturned);
        }

        [Theory]
        [InlineData("Micael Skywalker")]
        [InlineData("Skywalkeer")]
        [InlineData("Micael")]
        [InlineData("CCCCPrttrP")]
        public void ValidateTraveler_IncorrectInput_ExpectFalse(string name)
        {
            StarWarsApi api = new StarWarsApi();
            JObject jObject = api.GetTravelerDataAsync(name.ToLower()).Result;

            bool isTraveler = api.ValidateTraveler(jObject, name.ToLower());

            Assert.False(isTraveler);
        }

        [Theory]
        [InlineData("Luke SKYWALKER")]
        [InlineData("anakin skYwalker")]
        [InlineData("bB8")]
        [InlineData("Beru Whitesun Lars")]
        public void ValidateTraveler_CorrecttInput_ExpectTrue(string name)
        {
            StarWarsApi api = new StarWarsApi();
            JObject jObject = api.GetTravelerDataAsync(name.ToLower()).Result;

            bool isTraveler = api.ValidateTraveler(jObject, name.ToLower());

            Assert.True(isTraveler);
        }

        [Fact]
        public void FetchTravelerShipURI_FromRecievedJObject_FetchCorrectShipURI()
        {

            string name = "Luke SKYWalKeR";
            List<string> expectedURIs = new List<string>() { "https://swapi.co/api/starships/12/", "https://swapi.co/api/starships/22/" };

            StarWarsApi api = new StarWarsApi();
            JObject jObject = api.GetTravelerDataAsync(name.ToLower()).Result;
            List<string> actualURIs = api.FetchTravelerShipURI(jObject);

            Assert.Equal(expectedURIs, actualURIs);
        }

        [Fact]
        public void GetShipDataAsync_InsertListOfURI_ReturnShipValues()
        {
            string name = "Luke SKYWalKeR";

            Dictionary<string, double> ExpectedShipData = new Dictionary<string, double>();
            ExpectedShipData.Add("X-wing", 12.5);
            ExpectedShipData.Add("Imperial shuttle", 20);

            StarWarsApi api = new StarWarsApi();
            JObject jObject = api.GetTravelerDataAsync(name.ToLower()).Result;
            List<string> shipURIs = api.FetchTravelerShipURI(jObject);

            Dictionary<string, double> actualShipData = api.GetShipDataAsync(shipURIs).Result;

            Assert.Equal(ExpectedShipData, actualShipData);
        }
    }
}
