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
                Console.WriteLine("The Following Data Inserted To Database");
                DisplayReceipt(name);
/*
                    checkName = (from p in Context.Ticket
                                 where p.PersonName == name
                                 orderby p.ID descending
                                 select p).FirstOrDefault();
                if (checkName.PersonName==name)
                {
                    var person = (from t in Context.Ticket
                                  join r in Context.Receipt
                                  on t.ID equals r.TicketID
                                  where (t.PersonName == name)
                                  orderby t.ID descending
                                  select new
                                  {
                                      r.TicketID,
                                      t.PersonName,
                                      t.ShipName,
                                      t.DateTimeOfArrival,
                                      t.DateTimeOfDepature,
                                      r.TotalPrice
                                  }).ToList().FirstOrDefault();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var p in person)
                    {
                        Console.WriteLine(
                            "Ticket ID:\t {0}\n Name:\t\t {1}\n Ship Name:\t {2}\n Arrival Date:\t {3}\n Departure Date: {4}\n Total Price:\t ${5}\n\n",
                            p.TicketID, p.PersonName, p.ShipName, p.DateTimeOfArrival, p.DateTimeOfDepature, p.TotalPrice);
                    }
                    Console.ResetColor(); 
                }*/
            }
            catch (Exception)
            {
                Console.WriteLine("Data Inserting Failed");
                throw;
            }
        }
        private Ticket checkName;
        public void DisplayReceipt(string name)
        {
            try
            {
                 checkName = (from p in Context.Ticket
                                 where p.PersonName == name
                                 orderby p.ID descending
                                 select p).FirstOrDefault();

                if (checkName.PersonName == name)
                {
                    var data = (from ticket in Context.Ticket
                                join receipt in Context.Receipt
                                on ticket.ID equals receipt.TicketID
                                where (ticket.PersonName == name)
                                orderby ticket.ID descending
                                select new
                                {
                                    receipt.TicketID,
                                    ticket.PersonName,
                                    ticket.ShipName,
                                    ticket.DateTimeOfArrival,
                                    ticket.DateTimeOfDepature,
                                    receipt.TotalPrice
                                }).ToList().FirstOrDefault();

                    //Console.WriteLine("This Person Receipt Is Ready");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Ticket ID:\t{data.TicketID}\nPerson Name:\t{data.PersonName}\nShip Name:\t{data.ShipName}\n" +
                        $"Arrival Time:\t{data.DateTimeOfArrival}\nDeparture Time:\t{data.DateTimeOfDepature}\n" +
                        $"Total Price:\t{data.TotalPrice}\n");
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


            try
            {
                //var checkName = Context.Ticket
                //                .Where(person => person.PersonName == name)
                //                .Select
                //                .LastOrDefault();

                    Console.WriteLine("Person Removed From Database Successfully");
                    DisplayReceipt(name);
                if (checkName.PersonName == name)
                {
                    Context.Ticket.Remove(Context.Ticket.Where(n => n.PersonName == name).OrderByDescending(p => p.ID) .FirstOrDefault());
                    Context.SaveChanges();
           // Console.WriteLine("The Following Data Removed From Database");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Sorry, This Person Does Not Exists In Our Database");
                //Console.ResetColor(); 
            } 
        }

    }
}