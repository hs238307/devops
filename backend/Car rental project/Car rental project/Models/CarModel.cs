using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Models
{
    public class CarModel
    {
        public int id { get; set; }
        public string maker { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public string image { get; set; }
    }
}
