using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Data.Tables
{
    public class Cars
    {
        public int id { get; set; }
        public string maker { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public byte[] image { get; set; }
    }
}
