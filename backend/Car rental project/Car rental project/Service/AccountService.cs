using Car.Data;
using Car.Data.Tables;
using Car_rental_project.Interface;
using Car_rental_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Service
{
    public class AccountService : AccountInterface
    {
        private readonly AppDbContext _appDbContext;

        public AccountService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task DeleteToken(int id)
        {
            Auth auth = _appDbContext.Auth.FirstOrDefault(a => a.userId == id);
            _appDbContext.Remove(auth);
            await _appDbContext.SaveChangesAsync();
        }

        public string GetToken(int id)
        {
            Auth auth = _appDbContext.Auth.FirstOrDefault(a => a.userId == id);
            if(auth == null)
            {
                return "";
            }
            return auth.authToken;
        }

        public User GetUser(int id)
        {
            User user = _appDbContext.User.FirstOrDefault(u => u.id == id);
            return user;
        }

        public bool IsTokenExist(int id, string getToken)
        {
            string token = GetToken(id);
            if(token == getToken)
            {
                return true;
            }
            return false;
        }

        public bool IsUserAdmin(int id)
        {
            User user = _appDbContext.User.FirstOrDefault(u => u.id == id);
            if(user == null)
            {
                return false;
            }
            return user.isadmin;
        }

        public bool IsUserExist(int id)
        {
            User user = _appDbContext.User.FirstOrDefault(u => u.id == id);
            if(user==null)
            {
                return false;
            }
            return true;
        }

        public User LoginUser(Login login)
        {
            string username = login.username;
            string password = login.password;
            User user = _appDbContext.User.FirstOrDefault(u => u.username == username && u.password == password);
            return user;
        }

        public async Task<string> SetToken(int id)
        {
            Guid tokenGuid = Guid.NewGuid();
            string token = tokenGuid.ToString();
            Auth auth = new Auth
            {
                userId = id,
                authToken = token
            };
            _appDbContext.Add(auth);
            await _appDbContext.SaveChangesAsync();
            return token;
        }

       
    }
}
