using System;
using RestSharp;
using Newtonsoft.Json;

namespace SpacePort
{
    public class StarWarsApi
    {
        public string Path { get; } = "https://swapi.co/api/";
        public RestClient Client;

        public dynamic ShowData(string category)
        {
            Client = new RestClient(Path);
            var request = new RestRequest(category, Method.GET);
            //request.AddUrlSegment("ID", 1);
            var jsonResponse = Client.Execute(request);
            var obj = JsonConvert.DeserializeObject<dynamic>(jsonResponse.Content);
            //Console.WriteLine(obj);

            //foreach (var item in obj.results)
            //{
            //    Console.WriteLine("Name: {0} \n Gender: {1} ", item.name, item.gender);
            //}

            return obj;
            
        }
    }
}