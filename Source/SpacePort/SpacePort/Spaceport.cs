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
            totalCost = (int)Math.Ceiling(shipLength * 0.2 * duration);

            return totalCost;
        }

        public int CreateParkingLotAmount(double shipLength)
        {
            int lotAmount = 0;
            if (shipLength >= 1 || shipLength <= 499)
                lotAmount = 50;
            else if (shipLength >= 500 || shipLength <= 999)
                lotAmount = 30;
            else if (shipLength >= 1000 || shipLength <= 3499)
                lotAmount = 15;
            else if (shipLength >= 3500 || shipLength <= 4999)
                lotAmount = 4;
            else if (shipLength >= 5000 || shipLength <= 9999)
                lotAmount = 2;

            return lotAmount;
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
                    TicketID = ticket.ID,
                    TotalPrice = price
                };
                Context.Receipt.Add(receipt);
                Context.SaveChanges();
                Console.WriteLine("Data Inserted To Database Successfuly \n\n");
                Console.WriteLine("This Data Inserted To Database");

                var person = (from t in Context.Ticket
                             join r in Context.Receipt
                             on t.ID equals r.TicketID
                             where (t.PersonName == name)
                             select new
                             { 
                                 r.TicketID,
                                 t.PersonName,
                                 t.ShipName,
                                 t.DateTimeOfArrival,
                                 t.DateTimeOfDepature,
                                 r.TotalPrice
                             }).ToList();

                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var p in person)
                {
                    Console.WriteLine(
                        "Ticket ID:\t {0}\n Name:\t\t {1}\n Ship Name:\t {2}\n Arrival Date:\t {3}\n Departure Date: {4}\n Total Price:\t ${5}\n\n",
                        p.TicketID, p.PersonName, p.ShipName, p.DateTimeOfArrival, p.DateTimeOfDepature, p.TotalPrice);
                }
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.WriteLine("Data Inserting Failed");
                throw;
            }
        }
        public void DisplayReceipt(string name)
        {
            try
            {
                var checkName = Context.Ticket
                        .Where(person => person.PersonName == name)
                        .SingleOrDefault();

                if (checkName.PersonName == name)
                {
                    var data = (from ticket in Context.Ticket
                                join receipt in Context.Receipt
                                on ticket.ID equals receipt.TicketID
                                where (ticket.PersonName == name)
                                select new
                                {
                                    receipt.TicketID,
                                    ticket.PersonName,
                                    ticket.ShipName,
                                    ticket.DateTimeOfArrival,
                                    ticket.DateTimeOfDepature,
                                    receipt.TotalPrice
                                }).ToList();

                    Console.WriteLine("This Person Receipt Is Ready");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var p in data)
                    {
                        Console.WriteLine(
                            "Ticket ID:\t {0}\n Name:\t\t {1}\n Ship Name:\t {2}\n Arrival Date:\t {3}\n Departure Date: {4}\n Total Price:\t ${5}\n",
                            p.TicketID, p.PersonName, p.ShipName, p.DateTimeOfArrival, p.DateTimeOfDepature, p.TotalPrice);
                    }
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, This Person Does Not Exists In Our Database");
                Console.ResetColor();
            }
        }

        public void RemovePerson(string name)
        {
            Context.Ticket.Remove(Context.Ticket.Where(n => n.PersonName == name).FirstOrDefault());
            Context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Person Removed From Database");
            Console.ResetColor();
        }

    }
}