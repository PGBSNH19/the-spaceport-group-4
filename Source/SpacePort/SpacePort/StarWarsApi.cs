using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace SpacePort
{
    public class StarWarsApi
    {
        public string Path { get; } = "https://swapi.co/api/";       
        public RestClient Client = new RestClient("https://swapi.co/api/");

        public async Task<JObject> GetTravelerDataAsync(string name)
        {
            name = name.ToLower();
            var request = new RestRequest($"people/?search={name}", Method.GET);

            var response = await Client.ExecuteAsync(request);
            JObject jObject = JObject.Parse(response.Content);

            return jObject;
        }

        public bool ValidateTraveler(JObject jObject, string name)
        {
            name = name.ToLower();
            string actual = "";
            bool isVerified = false;


            if ((int)jObject["count"] == 1)
            {
                actual = (string)jObject.SelectToken("results[0].name");
                actual = actual.ToLower();
            }
            else if ((int)jObject["count"] == 0)
            {
                actual = "nope";
            }
            else
            {
                actual = "nope";
            }

            if (actual == name)
            {
                isVerified = true;
            }

            return isVerified;
        }

        public List<string> FetchTravelerShipURI(JObject jObject)
        {
            
            List<string> shipURI = new List<string>();

            foreach (var uri in jObject.SelectToken("results[0].starships"))
                shipURI.Add(uri.ToString());

            return shipURI;
        }

        public async Task<Dictionary<string,double>> GetShipDataAsync(List<string> shipURIs)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            
            foreach(var item in shipURIs)
            {
                var request = new RestRequest(item, Method.GET);

                var response = await Client.ExecuteAsync(request);
                JObject jObject = JObject.Parse(response.Content);
                dict.Add((string)jObject["name"], (double)jObject["length"]);
            }
            
            return dict;
        }
 

        //public static IRestResponse<Traveler> GetPersonData(string input)
        //{
        //    var client = new RestClient("https://swapi.co/api/");
        //    var request = new RestRequest(input, DataFormat.Json);
        //    var apiResponse = client.Get<Traveler>(request);
        //    return apiResponse;
        //}
    }
}