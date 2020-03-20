using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpacePort
{
    public class StarWarsApi
    {
        public string Path { get; } = "https://swapi.co/api/";
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public RestClient Client;
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

        public void ShipData()
        {
            //throw new NotImplementedException();
        }

        public void TravelerData()
        {
            //throw new NotImplementedException();
        }
    }
}