using RestSharp;
using SpacePort;
using System;
using System.Collections.Generic;
using Xunit;
using Newtonsoft.Json;
using System.Linq;

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

        [Theory]
        [InlineData("Micael Skywalker")]
        [InlineData("Skywalkeer")]
        [InlineData("Micael")]
        [InlineData("CCCCPrttrP")]
        public void TestFalseAsyncSearchTraveler(string name)
        {
            name = name.ToLower();
            StarWarsApi api = new StarWarsApi();
            string isTraveler = api.GetAsyncTraveler(name).Result;

            Assert.NotEqual(name, isTraveler);
        }

        [Theory]
        [InlineData("Luke SKYWALKER")]
        [InlineData("anakin skYwalker")]
        [InlineData("bB8")]
        [InlineData("Beru Whitesun Lars")]        
        public void TestTrueAsyncSearchTraveler(string name)
        {
            name = name.ToLower();
            StarWarsApi api = new StarWarsApi();
            string isTraveler = api.GetAsyncTraveler(name).Result;

            Assert.Equal(name,isTraveler);
        }



    }
}
