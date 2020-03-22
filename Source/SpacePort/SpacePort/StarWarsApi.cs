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
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public RestClient Client = new RestClient("https://swapi.co/api/");
        private int index = 0;

        public dynamic ShowData(string category)
        {
            category.ToLower();
            
            if (category == "people")
                index = 87;
            else if (category == "starships")
                index = 37;

            List<object> objList = new List<object>();
            Client = new RestClient(Path);
            for(int i = 1; i <= index; i++)
            {
                var request = new RestRequest(category + "/" + i, Method.GET);
                //request.AddUrlSegment("ID", 37);
                var jsonResponse = Client.Execute(request);
                var obj = JsonConvert.DeserializeObject<dynamic>(jsonResponse.Content);
                objList.Add(obj);
            }


            return 0;

            //Console.WriteLine(obj);

            //foreach (var item in obj.results)
            //{
            //    Console.WriteLine("Name: {0} \n Gender: {1} ", item.name, item.gender);
            //}
        }

        public List<string> ShipData()
        {
            List<string> ships = new List<string>();
            StartIndex = 1;
            EndIndex = 37;

            for(int i = StartIndex; i <= EndIndex; i++) 
            {
                var request = new RestRequest("starships/" + i, Method.GET);
                var response = Client.Execute(request);
                try 
                {
                    JObject obj = JObject.Parse(response.Content);
                    ships.Add(obj["starship_class"].ToString());
                }
                catch (NullReferenceException n)
                {
                    Console.WriteLine("Page " + i + " was null");
                }
            }
            return ships;
        }

        public List<string> TravelerData()
        {
            List<string> travelers = new List<string>();
            StartIndex = 1;
            EndIndex = 87;

            for (int i = StartIndex; i <= EndIndex; i++)
            {
                var request = new RestRequest("people/" + i, Method.GET);
                var response = Client.Execute(request);
                try
                {
                    JObject obj = JObject.Parse(response.Content);
                    travelers.Add(obj["name"].ToString());
                }
                catch (NullReferenceException n)
                {
                    Console.WriteLine("Page " + i + " was null");
                }
            }
            return travelers;
        }

        public async void StarShipData()
        {
            /* var client = new RestClient("https://swapi.co/api/");

             StartIndex = 1;
             EndIndex = 37;
             List<string> tmpList = new List<string>();

             for (int i = StartIndex; i <= EndIndex; i++)
             {

                 var request = new RestRequest("starships/{index}", DataFormat.Json);
                 request.AddParameter("index", i, ParameterType.UrlSegment);
                 var timeline = await client.GetAsync<StarShip>(request);

                 if (request != null)
                 {
                     tmpList.Add(timeline.StarShipClass);
                 }
                 Console.WriteLine(timeline.StarShipClass);               
             }*/

            //var client = new RestClient("https://swapi.co/api/");
            int index = 37;
            int startIndex = 1;
            List<string> tmpList = new List<string>();

            for (int i = startIndex; i <= index; i++)
            {
                var request = new RestRequest("starships/{index}", DataFormat.Json);
                request.AddParameter("index", i, ParameterType.UrlSegment);
                //var request = new RestRequest("starships/" + i, DataFormat.Json);
                var timeline = await Client.GetAsync<StarShip>(request);
                if(timeline.StarshipClass != null)
                {
                    tmpList.Add(timeline.StarshipClass);
                }
                Console.WriteLine(timeline.StarshipClass);

                
            }
            Console.WriteLine("LIST");
            foreach (string s in tmpList)
            {
                
                Console.WriteLine(s);
            }
            //return tmpList;

        }
    }
}