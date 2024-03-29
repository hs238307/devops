using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Models
{
    public class RentUserModel
    {
        public int id { get; set; }
        public string maker { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public int userId { get; set; }
        public int duration { get; set; }
        public int cost { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string username { get; set; }
    }
}
