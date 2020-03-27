using System.Collections.Generic;

namespace SpacePort
{
    public class Traveler
    {
        public string Name { get; set; }
        public string[] Starships { get; set; }
        
    }

    public class TravelerResult
    {
        public List<Traveler> Results { get; set; }
    }
}