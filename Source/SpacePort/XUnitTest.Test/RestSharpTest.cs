using RestSharp;
using SpacePort;
using System;
using System.Collections.Generic;
using Xunit;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace XUnitTest.Test
{
    public class RestSharpTest
    {
        [Fact]
        public void TestSimpleGet()
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest("people/", Method.GET);

            var content = client.Execute(request).Content;           
        }

        [Fact]
        public void createApiClass()
        {
            StarWarsApi api = new StarWarsApi();

            Assert.NotNull(api);
        }

        [Fact]
        public void CreateApifields()
        {
            StarWarsApi api = new StarWarsApi();
            string path = api.Path;
            RestClient client = api.Client;

            Assert.NotNull(api);
        }

        [Fact]
        public void TestPath()
        {
            StarWarsApi api = new StarWarsApi();
            Assert.Equal("https://swapi.co/api/", api.Path);
        }

        [Fact]
        public void FetchTravelerShipURI_FromRecievedJObject_FetchCorrectShipURI()
        {
            List<string> expectedURIs = new List<string>()
            { "https://swapi.co/api/starships/12/", "https://swapi.co/api/starships/22/" };

            JObject testObject = JObject.Parse(@"{
            'count': 1, 
            'next': null, 
            'previous': null, 
            'results': [
                {
                    'name': 'Luke Skywalker',                 
                    'starships': [
                        'https://swapi.co/api/starships/12/',
                        'https://swapi.co/api/starships/22/'
                        ]
                    }
                ]
            }");

            StarWarsApi api = new StarWarsApi();
            List<string> actualURIs = api.FetchTravelerShipURI(testObject);

            Assert.Equal(expectedURIs, actualURIs);
        }

        //[Fact]
        //public void FetchTravelerShipURI_FromRecievedJObjectToNoresult_FetchCorrectShipURI2()
        //{
        //    List<string> expectedURIs = new List<string>() { "https://swapi.co/api/starships/12/", "https://swapi.co/api/starships/22/" };
        //    JObject testObject = JObject.Parse(@"{
        //    'count': 1, 
        //    'next': null, 
        //    'previous': null, 
        //    'results': null}");

        //    StarWarsApi api = new StarWarsApi();
        //    List<string> actualURIs = api.FetchTravelerShipURI(testObject);

        //    Assert.Equal(expectedURIs, actualURIs);
        //}


    }
}   
