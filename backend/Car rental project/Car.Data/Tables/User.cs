using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Data.Tables
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isadmin { get; set; }
    }
}
