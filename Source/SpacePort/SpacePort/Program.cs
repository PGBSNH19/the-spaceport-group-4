using System;
using System.Collections.Generic;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Testing
            string[] arr = { "Large", "Medium", "Small", "Small" };

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string s in arr)
            {
                if (!dict.ContainsKey(s))
                    dict.Add(s, 10);                
            }

            foreach(KeyValuePair<string,int> k in dict)
                Console.WriteLine(k);

            Console.WriteLine("BUY");
            Buy("Large", dict);
            Buy("Large", dict);
            Buy("Medium", dict);
            Buy("Medium", dict);
            Buy("Medium", dict);
            Buy("Medium", dict);

            foreach (KeyValuePair<string, int> k in dict)
                Console.WriteLine(k);

            Console.WriteLine("SELL");
            Sell("Medium", dict);
            Sell("Medium", dict);

            foreach (KeyValuePair<string, int> k in dict)
                Console.WriteLine(k);
        }

        static void Buy(string type, Dictionary<string, int> dict)
        {
            dict[type] -=1;
        }

        static void Sell(string type, Dictionary<string, int> dict)
        {
            dict[type] +=1;
        }
    }
}
