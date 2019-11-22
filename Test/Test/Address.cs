using System.Collections.Generic;

namespace TestAddressa
{
    public class Address
    {
        public string country_code { get; set; }
        public string formatted { get; set; }
        public List<Component> Components { get; set; }
    }
}