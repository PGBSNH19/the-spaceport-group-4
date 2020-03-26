using SpacePort.Models;
using System;
using System.Collections.Generic;

namespace SpacePort
{
    public class Menu
    {
        static StarWarsApi swAPI = new StarWarsApi();
        static Spaceport spacePort = new Spaceport();
        public static string CustomerName { get; private set; }
        public static int MenuChoice { get; private set; }

        DateTime startTime;
        DateTime endTime;

        public static void Display()
        {
            Console.WriteLine("Hello, my friend. Stay awhile and listen");
            Console.WriteLine("I am A.S.P.P.A:  *BEEP* *BEEP*  Your Automated SpacePort Parking Assistent \n\r");

            Console.WriteLine("[1\tCheck In\t]");
            Console.WriteLine("[2\tCheck Out\t]");

            Console.Write("\n\rPlease Make a choice: ");
            MenuChoice = int.Parse(Console.ReadLine());

            if(MenuChoice == 1)
            {
                Console.Write("Please *BEEP* *BOOP* enter your name: ");
                CustomerSignIn();
                
                bool isValidated  = ValidateCustomer();
                if(isValidated == true)
                    DisplayShipTypes();
                else
                {
                    Console.WriteLine("*BEEP* Do.Or do not.There is no try. *BOOP*");
                    Console.Write("Your name please: ");
                    CustomerSignIn();
                }

                Console.WriteLine("Please enter your time of arrival (YYYY/MM/DD HH:MM): ");
                string arrivalInput = Console.ReadLine();
                DateTime startTime = DateTime.Parse(arrivalInput);
                Console.WriteLine("Please enter your time of depature (YYYY/MM/DD HH:MM): ");
                string depatureInput = Console.ReadLine();
                DateTime endTime = DateTime.Parse(depatureInput);
            }
            else if(MenuChoice == 2)
            {
                //Checkout method called, and check in database if user is checked in
            }
             
            //if starwarsperson not found: Retry and text: “Do. Or do not. There is no try.”

            //Checkin confirmation text: "The garbage’ll do!” 
            ///checkout text: "I find your lack of faith disturbing".



        }

        

        private static bool ValidateCustomer()
        {
            //return swAPI.GetTravelerAsync(CustomerName.ToLower()).Result; 

            return true;
        }

        public static void DisplayShipTypes()
        {
            spacePort.GetParkingLots();
            spacePort.GenerateLotAmount();
        }

        public static void CustomerSignIn()
        {
            
            CustomerName = Console.ReadLine();
        }
    }
}