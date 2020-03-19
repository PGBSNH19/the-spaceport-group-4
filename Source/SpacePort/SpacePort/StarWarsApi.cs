using System;
using RestSharp;
using Newtonsoft.Json;

namespace SpacePort
{
    public class StarWarsApi
    {

        public void ShowData()
        {
            const string path = "https://swapi.co/api/";
            var client = new RestClient(path);
            var requestClient = new RestRequest("people/", Method.GET);
            var jsonResponse = client.Execute(requestClient);

            var obj = JsonConvert.DeserializeObject<dynamic>(jsonResponse.Content);
            //Console.WriteLine(obj.results[0].name);

            foreach (var item in obj)
            {
                Console.WriteLine(item.results[0]);
                //Console.WriteLine("Name: {0} \n Gender: {1} " item.name, item.gender);
            }
        }
    }
}