using RestSharp;
using SpacePort;
using System;
using System.Collections.Generic;
using Xunit;
using Newtonsoft.Json;

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
            api.ShowData();

            Assert.NotNull(api);
        }
    }
}
