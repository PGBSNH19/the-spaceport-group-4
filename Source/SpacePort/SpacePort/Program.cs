using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using System.Linq;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");




            var client = new RestClient("https://swapi.co/api/");
            //client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("people", DataFormat.Json);

            var response = client.Get(request);

            //var name = response.Content.Where(x => x.namee == "Luke Skywalker" );
            //Testing
            //string[] arr = { "Large", "Medium", "Small", "Small" };

            //Dictionary<string, int> dict = new Dictionary<string, int>();

            //foreach (string s in arr)
            //{
            //    if (!dict.ContainsKey(s))
            //        dict.Add(s, 10);
            //}

            //foreach (KeyValuePair<string, int> k in dict)
            //    Console.WriteLine(k);

            //Console.WriteLine("BUY");
            //CheckInParking("Large", dict);
            //CheckInParking("Large", dict);
            //CheckInParking("Medium", dict);
            //CheckInParking("Medium", dict);
            //CheckInParking("Medium", dict);
            //CheckInParking("Medium", dict);

            //foreach (KeyValuePair<string, int> k in dict)
            //    Console.WriteLine(k);

            //Console.WriteLine("SELL");
            //CheckOutParking("Medium", dict);
            //CheckOutParking("Medium", dict);

            //foreach (KeyValuePair<string, int> k in dict)
            //    Console.WriteLine(k);
        }

        //static void CheckInParking(string type, Dictionary<string, int> dict)
        //{
        //    dict[type] -= 1;
        //}

        //static void CheckOutParking(string type, Dictionary<string, int> dict)
        //{
        //    dict[type] += 1;
        //}
    }
}
