using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Data.Tables
{
    public class Rent
    {
        public int id { get; set; }
        public string maker { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public byte[] image { get; set; }
        public int userId { get; set; }
        public int duration { get; set; }
        public int cost { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
