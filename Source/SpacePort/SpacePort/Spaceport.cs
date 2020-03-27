using SpacePort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpacePort
{
    public class Spaceport
    {
        StarWarsApi api = new StarWarsApi();

        public Dictionary<string, int> ShipTypes;
        private Dictionary<string, int> parkingCapacity;
        public void GetParkingLots()
        {
            //this.ShipTypes = api.GetShipDataAsync().Result;
        }

        public void GenerateLotAmount()
        {
            Random randomAmount = new Random();

            List<string> keys = new List<string>(ShipTypes.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                int amount = randomAmount.Next(0, 10);
                string key = keys[i];
                this.ShipTypes[key] = amount;
            }

            parkingCapacity = ShipTypes;
        }

        public bool CheckParkingAvalibility(string shipType)
        {
            int value = ShipTypes[shipType];
            return value > 0;
        }

        public bool CheckMaxLots(string shipType)
        {
            int value = ShipTypes[shipType];
            int maxValue = parkingCapacity[shipType];
            return value <= maxValue;
        }

        public void Park(string shipType)
        {
            ShipTypes[shipType] -= 1;
        }

        public void Leave(string shipType)
        {
            ShipTypes[shipType] += 1;
        }

        public int CalculateParkingTariff(string shipType)
        {



            //tmp value
            return 10;
        }


        /*public int ParkedTimeInMinutes()
        {
            var parked = TimeOfDepature - TimeOfArrival;
            return (int)parked.TotalMinutes;
        }*/

        public List<string> GenerateReceipt(DateTime startTime, DateTime dateTime, string shipType)
        {
            List<string> receiptTmp = new List<string>();

            //int cost = CalculateParkingTariff(shipType);



            return receiptTmp;


        }


        //instance of DataContext class
        DataContext Context = new DataContext();

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
                    Context.Ticket.Remove(Context.Ticket.Where(n => n.PersonName == name).OrderByDescending(p => p.ID).FirstOrDefault());
                    Context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}