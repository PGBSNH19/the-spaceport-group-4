using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {


            //Spaceport spacePort = new Spaceport();
            //spacePort.GetParkingLots();

            //Menu.DisplayMenu();


            Console.ReadKey();



            //Console.ReadKey();

            /*
            Ticket ticket = new Ticket();
            ticket.TimeOfArrival = new DateTime(2020, 03, 24, 15, 0, 0);
            ticket.TimeOfDepature = new DateTime(2020, 03, 24, 15, 50, 0);

            Console.WriteLine(ticket.ParkedTimeInMinutes());
            Console.ReadKey();
            */

            //StarWarsApi api = new StarWarsApi();
            //Dictionary<string, int> dict = api.GetAsyncShipData().Result;
            //Dictionary<string, int> dict = new Dictionary<string, int>();

            //string[] arr = { "Large", "Medium", "Small", "Small" };

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

        //async void WriteResult() { }

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
