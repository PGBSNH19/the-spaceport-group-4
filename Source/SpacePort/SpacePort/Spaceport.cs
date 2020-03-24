using System;
using System.Collections.Generic;

namespace SpacePort
{
    public class Spaceport
    {
        StarWarsApi api = new StarWarsApi();

        public Dictionary<string, int> ShipTypes;

        private void GetParkingLots()
        {
            this.ShipTypes = api.GetAsyncShipData().Result;
        }

        private void GenerateLotAmount()
        {
            Random randomAmount = new Random();

            List<string> keys = new List<string>(ShipTypes.Keys);
            for(int i = o; i < keys.Count; i++)
            {
                int amount = randomAmount.Next(0, 10);
                string key = keys[i];
                this.ShipTypes[key] = amount;
            }
        }

        private 

    }    
}