using System;
using System.Collections.Generic;

namespace SpacePort
{
    public class Spaceport
    {
        StarWarsApi api = new StarWarsApi();

        public Dictionary<string, int> ShipTypes;
        private Dictionary<string, int> parkingCapacity;
        private void GetParkingLots()
        {
            this.ShipTypes = api.GetShipDataAsync().Result;
        }

        private void GenerateLotAmount()
        {
            Random randomAmount = new Random();

            List<string> keys = new List<string>(ShipTypes.Keys);
            for(int i = 0; i < keys.Count; i++)
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

        public bool CheckMaxLots (string shipType)
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
    }    
}