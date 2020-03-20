using System;
using System.Collections.Generic;

namespace SpacePort
{
    public class Menu
    {
        static StarWarsApi api = new StarWarsApi();
        public static string SignIn { get; set; }

        public static void DisplayMenu()
        {
            Console.WriteLine("Welcome to Parking, please sign in by selecting your ship");
            DisplayShipTypes();
            Console.Write("Please enter your ship: ");
            SignIn = Console.ReadLine();
        }

        public static void DisplayShipTypes()
        {
            List<string> ships = api.ShipData();

            foreach (var s in ships)
            {
                Console.WriteLine(s);
            }
        }

        public static void CustomerSignIn()
        {
            List<string> traveler = api.TravelerData();

            foreach (var t in traveler)
            {
                Console.WriteLine(t);
            }
        }
    }
}