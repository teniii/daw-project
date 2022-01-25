using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string apartment { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public int postal_code { get; set; }

    }
}