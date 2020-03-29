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
        static bool notValidTime;

        public static int MenuChoice { get; private set; }

        public static void Display()
        {
            Console.WriteLine("Please press Enter to start the program");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                
                while (MenuChoice == 0)
                {
                    DisplayMain();
                    Console.Write("\n\rPlease Make a choice: ");
                    MenuChoice = int.Parse(Console.ReadLine());
                }

                if (MenuChoice == 1)
                {
                    Console.Write("Please enter your name: ");
                    TravelerSignIn();

                    bool valid = false;
                    while (valid == false)
                    {
                        valid = ValidateTraveler();

                        if(valid == true)
                        {                            
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=CONFIRMATION CONFIRMED= *BEEP*\n\rWell met, servant.\n\r");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {                           
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\r*BEEP* So certain were you. Go back and closer you must look. *BOOP*");
                            Console.ResetColor();
                            Console.Write("Try again: ");
                            TravelerSignIn();
                        }

                    }

                    do
                    {
                        Console.Write("Please enter your date and time of arrival (YYYY-MM-DD HH:MM): ");
                        string arrivalInput = Console.ReadLine();
                        arrivalTime = InputDate(arrivalInput);
                        Console.Write("Please enter your date and time of depature (YYYY-MM-DD HH:MM): ");
                        string depatureInput = Console.ReadLine();
                        departureTime = InputDate(depatureInput);
                        Console.Clear();
                        
                        if (arrivalTime > departureTime)
                        {
                            Console.WriteLine("Error no time traveling allowed!");
                            notValidTime = true;
                        }
                        else
                        {
                            notValidTime = false;
                        }

                    } while (notValidTime);

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
                        Console.WriteLine("Please press any key to return to main menu");;
                        Console.ReadKey();
                        Console.Clear();
                        MenuChoice = 0;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You’re fulfilling your destiny, Traveler. Become my apprentice. Learn to use the Dark Side of the Force.");
                        Console.ResetColor();
                        Console.WriteLine("Please press any key to return to main menu");
                        Console.ReadKey();
                        MenuChoice = 0;
                    }                
                }
                else if (MenuChoice == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\rI find your lack of faith disturbing.\n\r");
                    Console.ResetColor();

                    Console.Write("To check out, please enter your name: ");
                    string name = Console.ReadLine();

                    try
                    {
                        Dictionary<string, double> ships = GetShips();
                        spacePort.Undock(ships[shipName]);
                        spacePort.DisplayReceipt(name);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Please Check in before Check out");
                    }


                    Console.WriteLine("\n\rPlease press any key to return to main menu");
                    Console.ReadKey();
                    Console.Clear();
                    
                    
                    MenuChoice = 0;
                    Console.WriteLine("Please press Enter to start the program");
                }
            }
        }

        private static void DisplayMain()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, my friend. Stay awhile and listen");
            Console.WriteLine("I am A.S.P.P.A:  *BEEP* *BEEP*  Your Automated SpacePort Parking Assistent \n\r");
            Console.ResetColor();

            Console.WriteLine("[1\tCheck In\t]");
            Console.WriteLine("[2\tCheck Out\t]");
        }
        private static DateTime InputDate(string input)
        {
            DateTime dateTime = DateTime.Parse(input);

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
                Console.WriteLine($"[{index}.\t{key,-30}Avaliable lots: {lot,-10}Total Cost: {totalCost}C]");
                index++;
            }
          
            return keys;
        }

        public static void ParkShip(Dictionary<string,double> ships, List<string> keys)
        {
            Console.Write("\n\rPlese select ship to Check In: ");
            int ship = int.Parse(Console.ReadLine());

            for (int i = 0; i <= ships.Count; i++)
            {
                if (ship == i)
                    shipName = keys[i - 1];
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\rThe garbage’ll do!");
            Console.ResetColor();
        }

        public static void Pay()
        {
            Console.WriteLine($"Please pay {totalCost} credits to park your ship");
        }

        public static void ParkingConfirmation()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for choosing to stay at a Far Far Away Starport\n\r");
            Console.ResetColor();

            spacePort.InsertDataToTciketDB(travelerName, shipName, arrivalTime, departureTime, totalCost);
        }

        public static void TravelerSignIn()
        {
            travelerName = Console.ReadLine();
        }
    }
}