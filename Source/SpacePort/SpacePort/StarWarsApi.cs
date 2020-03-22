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

        public async void GetAsyncShipData()
        {
            EndIndex = 37;

            List<string> tmpList = new List<string>();

            for (int i = StartIndex; i <= EndIndex; i++)
            {
                var request = new RestRequest("starships/{index}", DataFormat.Json);
                request.AddParameter("index", i, ParameterType.UrlSegment);

                var timeline = await Client.GetAsync<StarShip>(request);

                if (timeline.StarshipClass != null)
                {
                    tmpList.Add(timeline.StarshipClass);
                }
                Console.WriteLine(timeline.StarshipClass);
            }

            //for testing
            Console.WriteLine("\n\rLIST");
            foreach (string s in tmpList)
            {
                Console.WriteLine(s);
            }
        }

        /*public async void GetAsyncTravelerData()
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
        }*/

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
    }
}