using System;
using RestSharp;
using Newtonsoft.Json;

namespace SpacePort
{
    public class StarWarsApi
    {
        public string Path { get; } = "https://swapi.co/api/";
        public RestClient Client { get; set; }

        public void ShowData()
        {
            //const string path = "https://swapi.co/api/";
            Client = new RestClient(Path);
            var request = new RestRequest("people",Method.GET);
            var jsonResponse = client.Execute(request);
            var obj = JsonConvert.DeserializeObject<dynamic>(jsonResponse.Content);
            //Console.WriteLine(obj);

            foreach (var item in obj.results)
            {
                Console.WriteLine("Name: {0} \n Gender: {1} ", item.name, item.gender);
            }
        }
    }
}