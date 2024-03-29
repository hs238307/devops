using Car.Data.Tables;
using Car_rental_project.Interface;
using Car_rental_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly AccountInterface _accountInterface;

        public AccountController(AccountInterface accountInterface)
        {
            _accountInterface = accountInterface;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] Login model)
        {
            User userExist = _accountInterface.LoginUser(model);
            if (userExist == null)
            {
                var error = new { isExist = false };
                return NotFound(error);
            }

            string token = _accountInterface.GetToken(userExist.id);
            if (token != "")
            {
                await _accountInterface.DeleteToken(userExist.id);
            }
            string setToken = await _accountInterface.SetToken(userExist.id);

            var success = new { userId = userExist.id, isAdmin = userExist.isadmin, name = userExist.username, token = setToken };
            return Ok(success);
        }

        [HttpPost("signout")]
        public async Task<IActionResult> Post([FromBody] Token token)
        {
            bool isTokenExist = _accountInterface.IsTokenExist(token.userId, token.token);
            if (isTokenExist)
            {
                await _accountInterface.DeleteToken(token.userId);
                var success = new { message = "Sign Out Successful!" };
                return Ok(success);
            }
            var error = new { message = "User Id or Token Doesn't match!" };
            return BadRequest(error);
        }


    }
}
