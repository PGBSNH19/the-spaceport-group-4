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

        static DateTime startTime = new DateTime();
        static DateTime endTime = new DateTime();

        public static string CustomerName { get; private set; }
        public static int MenuChoice { get; private set; }

        public static void Display()
        {
            Console.WriteLine("Hello, my friend. Stay awhile and listen");
            Console.WriteLine("I am A.S.P.P.A:  *BEEP* *BEEP*  Your Automated SpacePort Parking Assistent \n\r");

            Console.WriteLine("[1\tCheck In\t]");
            Console.WriteLine("[2\tCheck Out\t]");

            Console.Write("\n\rPlease Make a choice: ");
            MenuChoice = int.Parse(Console.ReadLine());

            if (MenuChoice == 1)
            {
                Console.Write("Please *BEEP* *BOOP* enter your name: ");
                CustomerSignIn();

                bool valid = false;
                while (valid == false)
                {
                    valid = ValidateCustomer();

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
                        CustomerSignIn();
                    }

                }

                Console.Write("Please enter your time of arrival (YYYY/MM/DD HH:MM): ");
                string arrivalInput = Console.ReadLine();
                InputDate(arrivalInput, startTime);
                Console.Write("Please enter your time of depature (YYYY/MM/DD HH:MM): ");
                string depatureInput = Console.ReadLine();
                InputDate(depatureInput, endTime);
               // Console.Clear();

                DisplayCustomerShips();
            }
            else if (MenuChoice == 2)
            {
                //Checkout method called, and check in database if user is checked in
            }

            //Checkin confirmation text: "The garbage’ll do!” 
            ///checkout text: "I find your lack of faith disturbing".

        }

        private static void InputDate(string input, DateTime dateTime)
        {
            dateTime = DateTime.Parse(input);
            //spaceport.GetDate(dateTime);
        }

        private static bool ValidateCustomer()
        {
            jObject = swAPI.GetTravelerDataAsync(CustomerName).Result;
            bool isValid = swAPI.ValidateTraveler(jObject, CustomerName);
            return isValid;
        }

        public static void DisplayCustomerShips()
        {
            List<string> shipURI = swAPI.FetchTravelerShipURI(jObject);
            Dictionary<string, double> ships = swAPI.GetShipDataAsync(shipURI).Result;

            Console.WriteLine("Avaliable ships: ");
            int lot = 5;
            foreach(var item in ships)
            {
                Console.WriteLine($"[1.\t{item.Key}\tAvaliable lots: {lot}]");
                lot += 3;
            }

            Console.Write("Plese select ship to Check In: ");
            Console.ReadLine();
        }

        public static void CustomerSignIn()
        {

            CustomerName = Console.ReadLine();
        }
    }
}