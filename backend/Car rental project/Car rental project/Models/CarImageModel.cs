using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Models
{
    public class CarImageModel
    {
        public int userId { get; set; }
        public int price { get; set; }
        public string token { get; set; }
        public IFormFile image { get; set; }
        public string maker { get; set; }
        public string carModel { get; set; }
        
    }
}
