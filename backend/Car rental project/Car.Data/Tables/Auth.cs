using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Data.Tables
{
    public class Auth
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string authToken { get; set; }
    }
}
