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
            Spaceport s = new Spaceport();

            // pass these values.  #string name, string shipN, DateTime arrTime, DateTime dpTime, int price
            s.InsertDataToTciketDB("Mirko", "Ranger", Convert.ToDateTime("2020-03-26 12:30:00"), Convert.ToDateTime("2020-03-27 14:30:00"), 500);
            s.DisplayReceipt("Mike"); // shows receipt by person name
            s.RemovePerson("Mirko");  // remove someone from database
            Console.ReadKey();


            /*
                        //Spaceport spacePort = new Spaceport();
                        //spacePort.GetParkingLots();

                        //Menu.DisplayMenu();






                        //Console.ReadKey();

                        Ticket ticket = new Ticket();
                        ticket.TimeOfArrival = new DateTime(2020, 03, 24, 15, 0, 0);
                        ticket.TimeOfDepature = new DateTime(2020, 03, 24, 15, 50, 0);

                        Console.WriteLine(ticket.ParkedTimeInMinutes());
                        //Spaceport spacePort = new Spaceport();
                        //spacePort.GetParkingLots();
                        //Menu.Display();
                        Console.ReadKey();
                        */
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
