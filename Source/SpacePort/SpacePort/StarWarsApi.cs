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
        //public string Path { get; } = "https://swapi.co/api/";
        //public int StartIndex { get; } = 1;
        //public int EndIndex { get; set; }

        public RestClient Client = new RestClient("https://swapi.co/api/");

        //public async Task<Dictionary<string, int>> GetShipDataAsync()
        //{
        //    EndIndex = 37;

        //    Dictionary<string, int> tmpDict = new Dictionary<string, int>();

        //    for (int i = StartIndex; i <= EndIndex; i++)
        //    {
        //        var request = new RestRequest("starships/{index}", DataFormat.Json);
        //        request.AddParameter("index", i, ParameterType.UrlSegment);

        //        var timeline = await Client.GetAsync<StarShip>(request);

        //        if (timeline.StarshipClass != null)
        //        {
        //            if (!tmpDict.ContainsKey(timeline.StarshipClass))
        //                tmpDict.Add(timeline.StarshipClass, 0);
        //        }
        //        Console.WriteLine(timeline.StarshipClass);


        //    }

        //    //for testing
        //    Console.WriteLine("\n\rLIST");
        //    foreach (KeyValuePair<string,int> s in tmpDict)
        //    {
        //        Console.WriteLine(s);
        //    }

        //    return tmpDict;
        //}

        //public async Task<List<string>> GetTravelerDataAsync()
        //{
        //    EndIndex = 87;

        //    List<string> tmpList = new List<string>();

        //    for (int i = StartIndex; i <= EndIndex; i++)
        //    {
        //        var request = new RestRequest("people/{index}", DataFormat.Json);
        //        request.AddParameter("index", i, ParameterType.UrlSegment);
        //        var timeline = await Client.GetAsync<Traveler>(request);

        //        if (timeline.Name != null)
        //        {
        //            tmpList.Add(timeline.Name);
        //        }
        //        Console.WriteLine(timeline.Name);
        //    }

        //    //for testing
        //    Console.WriteLine("\n\rLIST");
        //    foreach (string s in tmpList)
        //    {
        //        Console.WriteLine(s);
        //    }

        //    return tmpList;
        //}



        //public async Task<bool> GetTravelerAsync(string name)
        //{
        //    name = name.ToLower();
        //    bool isEqual = false;

        //    //string req = $"\u003Fsearch={name}";
        //    //var request = new RestRequest($"people/{req}", Method.GET);

        //    var request = new RestRequest($"people/?search={name}", Method.GET);

        //    var response = await Client.ExecuteAsync(request);
        //    JObject obj = JObject.Parse(response.Content);

        //    string actual = "";

        //    if ((int)obj["count"] == 1)
        //    {
        //        actual = (string)obj.SelectToken("results[0].name");
        //        actual = actual.ToLower();                
        //    }
        //    else if((int)obj["count"] == 0)
        //    {
        //        actual = "nope";
        //    }               
        //    else
        //    {
        //        actual = "nope";
        //    }

        //    if (actual == name)
        //    {
        //        isEqual = true;
        //    }

        //    return isEqual;
        //}

        public async Task<JObject> GetTravelerDataAsync(string name)
        {
            name = name.ToLower();
            var request = new RestRequest($"people/?search={name}", Method.GET);

            var response = await Client.ExecuteAsync(request);
            JObject jObject = JObject.Parse(response.Content);

            //VerifyTraveler(obj, name)

            return jObject;
        }

        public bool VerifyTraveler(JObject jObject, string name)
        {
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

        public List<string> FetchTravelerShips(JObject jObject)
        {
            List<string> shipURI = new List<string>();

            foreach (var uri in jObject.SelectToken("results[0].starships"))
                shipURI.Add(uri.ToString());

            return shipURI;
        }

        public async Task<Dictionary<string,double>> GetShipData(string shipURI)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();

            var request = new RestRequest(shipURI, Method.GET);

            var response = await Client.ExecuteAsync(request);
            JObject jObject = JObject.Parse(response.Content);
            dict.Add((string)jObject["name"], (double)jObject["length"]);

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