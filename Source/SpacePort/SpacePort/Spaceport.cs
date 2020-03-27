using SpacePort.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePort
{
    public class Spaceport
    {
        //instance of DataContext class
        DataContext Context = new DataContext();
        Dictionary<string, int> parkingLots = new Dictionary<string, int>()
        {
            ["Micro"] = 50,
            ["Small"] = 30,
            ["Medium"] = 15,
            ["Large"] = 6,
            ["Largest"] = 6,
            ["Mega"] = 2
        };

        
        /*public bool CheckParkingAvalibility(string shipType)
        {
            int value = ShipTypes[shipType];
            return value > 0;
        }*/

        /*public bool CheckMaxLots(string shipType)
        {
            int value = ShipTypes[shipType];
            int maxValue = parkingCapacity[shipType];
            return value <= maxValue;
        }*/

        /*public void Park(string shipType)
        {
            ShipTypes[shipType] -= 1;
        }

        public void Leave(string shipType)
        {
            ShipTypes[shipType] += 1;
        }*/

        public double CalculateStayDuration(DateTime arrivalTime, DateTime departureTime)
        {
            TimeSpan timeSpan = departureTime - arrivalTime;
            double totalHours = timeSpan.TotalHours;

            return totalHours;   
            
        }

        public int CalculateParkingTariff(double shipLength, double duration)
        {
            int totalCost = 0;
            int lotCost = 0;

            if (shipLength >= 1 && shipLength <= 499)
                lotCost = 100;

            else if (shipLength >= 500 && shipLength <= 999)
                lotCost = 200;

            else if (shipLength >= 1000 && shipLength <= 3499)
                lotCost = 350;

            else if (shipLength >= 3500 && shipLength <= 4999)
                lotCost = 450;

            else if (shipLength >= 5000 && shipLength <= 9999)
                lotCost = 750;

            else if (shipLength > 10000)
                lotCost = 2500;
            
            totalCost = (int)Math.Ceiling(lotCost * duration);

            return totalCost;
        }

        public int CalculateParkingAvailability(double shipLength)
        {
            int lotsAvailable = 0;

            if (shipLength >= 1 && shipLength <= 499)
                lotsAvailable = parkingLots["Micro"];

            else if (shipLength >= 500 && shipLength <= 999)
                lotsAvailable = parkingLots["Small"];

            else if (shipLength >= 1000 && shipLength <= 3499)
                lotsAvailable = parkingLots["Medium"];

            else if (shipLength >= 3500 && shipLength <= 4999)
                lotsAvailable = parkingLots["Large"];

            else if (shipLength >= 5000 && shipLength <= 9999)
                lotsAvailable = parkingLots["Largest"];

            else if (shipLength > 10000)
                lotsAvailable = parkingLots["Mega"];

            return lotsAvailable;
        }

        public void Docking(double shipLength)
        {
            if (shipLength >= 1 && shipLength <= 499)
                parkingLots["Micro"] -=1;

            else if (shipLength >= 500 && shipLength <= 999)
                parkingLots["Small"] -=1;

            else if (shipLength >= 1000 && shipLength <= 3499)
                parkingLots["Medium"] -=1;

            else if (shipLength >= 3500 && shipLength <= 4999)
                parkingLots["Large"] -=1;

            else if (shipLength >= 5000 && shipLength <= 9999)
                parkingLots["Largest"] -=1;

            else if (shipLength > 10000)
                parkingLots["Mega"] -=1;
        }

        public void Undocking(double shipLength)
        {
            if (shipLength >= 1 && shipLength <= 499)
                parkingLots["Micro"] += 1;

            else if (shipLength >= 500 && shipLength <= 999)
                parkingLots["Small"] += 1;

            else if (shipLength >= 1000 && shipLength <= 3499)
                parkingLots["Medium"] += 1;

            else if (shipLength >= 3500 && shipLength <= 4999)
                parkingLots["Large"] += 1;

            else if (shipLength >= 5000 && shipLength <= 9999)
                parkingLots["Largest"] += 1;

            else if (shipLength > 10000)
                parkingLots["Mega"] += 1;
        }

        //Inserting Data to Database
        public void InsertDataToTciketDB(string name, string shipN, DateTime arrTime, DateTime dpTime, int price)
        {
            try
            {
                Ticket ticket = new Ticket
                {
                    PersonName = name,
                    ShipName = shipN,
                    DateTimeOfArrival = arrTime,
                    DateTimeOfDepature = dpTime,
                };
                Context.Ticket.Add(ticket);
                Context.SaveChanges();

                Receipt receipt = new Receipt
                {
                    TicketID = ticket.TicketID,
                    TotalPrice = price
                };
                Context.Receipt.Add(receipt);
                Context.SaveChanges();
                Console.WriteLine("The Following Data Inserted To Database");
                DisplayReceipt(name);
            }
            catch (Exception)
            {
                Console.WriteLine("Data Inserting Failed");
            }
        }
        private Ticket checkName;
        public void DisplayReceipt(string name)
        {
            try
            {
                checkName = (from p in Context.Ticket
                             where p.PersonName == name
                             orderby p.TicketID descending
                             select p).FirstOrDefault();

                if (checkName.PersonName == name)
                {
                    var data = (from ticket in Context.Ticket
                                join receipt in Context.Receipt
                                on ticket.TicketID equals receipt.TicketID
                                where (ticket.PersonName == name)
                                orderby ticket.TicketID descending
                                select new
                                {
                                    receipt.TicketID,
                                    ticket.PersonName,
                                    ticket.ShipName,
                                    ticket.DateTimeOfArrival,
                                    ticket.DateTimeOfDepature,
                                    receipt.TotalPrice
                                }).ToList().FirstOrDefault();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Ticket ID:\t{data.TicketID}\nPerson Name:\t{data.PersonName}\nShip Name:\t{data.ShipName}\n" +
                        $"Arrival Time:\t{data.DateTimeOfArrival}\nDeparture Time:\t{data.DateTimeOfDepature}\n" +
                        $"Total Price:\t{data.TotalPrice}");
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, This Person Does Not Exists In Our Database\n");
                Console.ResetColor();
            }
        }

        public void RemovePerson(string name)
        {
            try
            {
                Console.WriteLine("The Following Data Removed From Database");
                DisplayReceipt(name);
                if (checkName.PersonName == name)
                {
                    Context.Ticket.Remove(Context.Ticket.Where(n => n.PersonName == name).OrderByDescending(p => p.TicketID).FirstOrDefault());
                    Context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}