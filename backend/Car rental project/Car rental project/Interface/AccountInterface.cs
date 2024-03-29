using Car.Data.Tables;
using Car_rental_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Interface
{
    public interface AccountInterface
    {
        public User LoginUser(Login login);
        public Task<string> SetToken(int id);
        public string GetToken(int id);
        public Task DeleteToken(int id);
        public bool IsTokenExist(int id, string getToken);
        public bool IsUserAdmin(int id);
        public bool IsUserExist(int id);
        public User GetUser(int id);
    }
}
