using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SpacePort
{
    public class Menu
    {
        static StarWarsApi swAPI = new StarWarsApi();
        static Spaceport spacePort = new Spaceport();

        static JObject jObject = new JObject();

        static string travelerName = "";
        static string shipName = "";
        static DateTime arrivalTime;
        static DateTime departureTime;
        static int totalCost = 0;
        static double duration;

        public static int MenuChoice { get; private set; }

        public static void Display()
        {
            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {
                //Console.WriteLine("Hello, my friend. Stay awhile and listen");
                //Console.WriteLine("I am A.S.P.P.A:  *BEEP* *BEEP*  Your Automated SpacePort Parking Assistent \n\r");

                //Console.WriteLine("[1\tCheck In\t]");
                //Console.WriteLine("[2\tCheck Out\t]");

                //Console.Write("\n\rPlease Make a choice: ");
                //MenuChoice = int.Parse(Console.ReadLine());
                while (MenuChoice == 0)
                {
                    DisplayMain();
                    Console.Write("\n\rPlease Make a choice: ");
                    MenuChoice = int.Parse(Console.ReadLine());
                }

                if (MenuChoice == 1)
                {
                    Console.Write("Please *BEEP* *BOOP* enter your name: ");
                    TravelerSignIn();

                    bool valid = false;
                    while (valid == false)
                    {
                        valid = ValidateTraveler();

                        if(valid == true)
                        {
                            Console.Clear();
                            Console.WriteLine("=CONFIRMATION CONFIRMED= *BEEP* Well met, servant.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("*BEEP* So certain were you. Go back and closer you must look. *BOOP*");
                            Console.Write("Try again: ");
                            TravelerSignIn();
                        }

                    }

                    Console.Write("Please enter your date and time of arrival (YYYY-MM-DD HH:MM): ");
                    string arrivalInput = Console.ReadLine();
                    arrivalTime = InputDate(arrivalInput);
                    Console.Write("Please enter your date and time of depature (YYYY/MM/DD HH:MM): ");
                    string depatureInput = Console.ReadLine();
                    departureTime = InputDate(depatureInput);

                    Dictionary<string, double> ships = GetShips();
                    List<string> keys = DisplayTravelerShips(ships);

                    ParkShip(ships, keys);
                    Pay();
                    Console.Write("Yes / No :");
                    string park = Console.ReadLine();

                    if(park.ToLower() == "yes")
                    {
                        ParkingConfirmation();
                        spacePort.Dock(ships[shipName]);
                        Console.WriteLine("* BEEP* Please press any key to return to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        MenuChoice = 0;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You’re fulfilling your destiny, Traveler. Become my apprentice. Learn to use the Dark Side of the Force.");
                        Console.ResetColor();
                        Console.WriteLine("* BEEP* Please press any key to return to main menu");
                        Console.ReadKey();
                        MenuChoice = 0;
                    }                
                }
                else if (MenuChoice == 2)
                {
                    //Checkout method called, and check in database if user is checked in
                    Console.WriteLine("\n\rI find your lack of faith disturbing.\n\r");
                    Console.Write("To check out, please enter your name: ");
                    string name = Console.ReadLine();
                    Dictionary<string, double> ships = GetShips();
                    spacePort.Undock(ships[shipName]);
                    spacePort.DisplayReceipt(name);
                    Console.WriteLine("\n\r* BEEP* Please press any key to return to main menu");
                    Console.Clear();
                    Console.ReadKey();
                    
                    MenuChoice = 0;
                }
            }
        }

        private static void DisplayMain()
        {
            Console.WriteLine("Hello, my friend. Stay awhile and listen");
            Console.WriteLine("I am A.S.P.P.A:  *BEEP* *BEEP*  Your Automated SpacePort Parking Assistent \n\r");

            Console.WriteLine("[1\tCheck In\t]");
            Console.WriteLine("[2\tCheck Out\t]");

            //Console.Write("\n\rPlease Make a choice: ");
            //MenuChoice = int.Parse(Console.ReadLine());
        }
        private static DateTime InputDate(string input)
        {
            DateTime dateTime = DateTime.Parse(input);
            //spaceport.GetDate(dateTime);

            return dateTime;
        }

        private static bool ValidateTraveler()
        {
            jObject = swAPI.GetTravelerDataAsync(travelerName).Result;
            bool isValid = swAPI.ValidateTraveler(jObject, travelerName);
            return isValid;
        }

        public static Dictionary<string, double> GetShips()
        {
            List<string> shipURI = swAPI.FetchTravelerShipURI(jObject);
            Dictionary<string, double> ships = swAPI.GetShipDataAsync(shipURI).Result;

            return ships;
        }

        public static List<string> DisplayTravelerShips(Dictionary<string, double> ships)
        {

            List<string> keys = new List<string>(ships.Keys);
            duration = spacePort.CalculateStayDuration(arrivalTime, departureTime);

            Console.WriteLine("Avaliable ships: \n\r");

            int index = 1;
            foreach (string key in keys)
            {
                int lot = spacePort.CalculateParkingAvailability(ships[key]);
                totalCost = spacePort.CalculateParkingTariff(ships[key], duration);
                Console.WriteLine($"[{index}.\t{key}\t\t\tAvaliable lots: {lot}\tTotal Cost: {totalCost}]");
                index++;
            }
          
            return keys;
        }

        public static void ParkShip(Dictionary<string,double> ships, List<string> keys)
        {
            Console.Write("Plese select ship to Check In: ");
            int ship = int.Parse(Console.ReadLine());
            //string shipName = "";
            for (int i = 0; i <= ships.Count; i++)
            {
                if (ship == i)
                    shipName = keys[i - 1];
            }
            Console.WriteLine("The garbage’ll do!");        
        }

        public static void Pay()
        {
            Console.WriteLine($"Please pay {totalCost} credits to park your ship");
        }

        public static void ParkingConfirmation()
        {
            Console.WriteLine("Thank you for choosing to stay at a Far Far Away Starport");

            spacePort.InsertDataToTciketDB(travelerName, shipName, arrivalTime, departureTime, totalCost);
        }

        public static void TravelerSignIn()
        {

            travelerName = Console.ReadLine();
        }
    }
}