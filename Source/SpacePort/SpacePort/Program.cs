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
            //Spaceport s = new Spaceport();

            //// pass these values.  #string name, string shipN, DateTime arrTime, DateTime dpTime, int price
            //s.InsertDataToTciketDB("Mirko", "Ranger", Convert.ToDateTime("2020-03-26 12:30:00"), Convert.ToDateTime("2020-03-27 14:30:00"), 500);
            //s.DisplayReceipt("Mike"); // shows receipt by person name
            //s.RemovePerson("Mirko");  // remove someone from database
            ////Console.ReadKey();
            Console.ReadKey();
            Menu.Display();


        }



    }
}
