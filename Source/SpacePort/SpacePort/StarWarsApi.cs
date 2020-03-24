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
        public int StartIndex { get; } = 1;
        public int EndIndex { get; set; }

        public RestClient Client = new RestClient("https://swapi.co/api/");

        public async Task<Dictionary<string, int>> GetAsyncShipData()
        {
            EndIndex = 37;

            Dictionary<string, int> tmpDict = new Dictionary<string, int>();

            for (int i = StartIndex; i <= EndIndex; i++)
            {
                var request = new RestRequest("starships/{index}", DataFormat.Json);
                request.AddParameter("index", i, ParameterType.UrlSegment);

                var timeline = await Client.GetAsync<StarShip>(request);

                if (timeline.StarshipClass != null)
                {
                    if (!tmpDict.ContainsKey(timeline.StarshipClass))
                        tmpDict.Add(timeline.StarshipClass, 0);
                }
                Console.WriteLine(timeline.StarshipClass);
            }

            //for testing
            Console.WriteLine("\n\rLIST");
            foreach (KeyValuePair<string,int> s in tmpDict)
            {
                Console.WriteLine(s);
            }

            return tmpDict;
        }

        public async Task<List<string>> GetAsyncTravelerData()
        {
            EndIndex = 87;

            List<string> tmpList = new List<string>();

            for (int i = StartIndex; i <= EndIndex; i++)
            {
                var request = new RestRequest("people/{index}", DataFormat.Json);
                request.AddParameter("index", i, ParameterType.UrlSegment);
                var timeline = await Client.GetAsync<Traveler>(request);
                
                if (timeline.Name != null)
                {
                    tmpList.Add(timeline.Name);
                }
                Console.WriteLine(timeline.Name);
            }

            //for testing
            Console.WriteLine("\n\rLIST");
            foreach (string s in tmpList)
            {
                Console.WriteLine(s);
            }

            return tmpList;
        }

        public async Task<bool> GetAsyncTraveler(string name)
        {
            name = name.ToLower();
            bool isEqual = false;

            string req = $"\u003Fsearch={name}";
            
            var request = new RestRequest($"people/{req}", Method.GET);

            var response = await Client.ExecuteAsync(request);
            JObject obj = JObject.Parse(response.Content);

            string actual = "";

            if ((int)obj["count"] == 1)
            {
                actual = (string)obj.SelectToken("results[0].name");
                actual = actual.ToLower();

                
            }
            else if((int)obj["count"] == 0)
            {
                actual = "nope";
            }               
            else
            {
                actual = "nope";
            }

            if (actual == name)
            {
                isEqual = true;
            }

            return isEqual;
        }
    }
}