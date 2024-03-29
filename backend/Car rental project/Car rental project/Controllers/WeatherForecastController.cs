using Car.Data;
using Car.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext appDbContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext _appDbContext)
        {
            _logger = logger;
            appDbContext = _appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //User user = new User
            //{
            //    username = "hemantadmin2",
            //    password = "hemant@admin2",
            //    isadmin = true
            //};
            //
            //appDbContext.SaveChanges();
            //appDbContext.User.Add(user);
            //var success = new { message = "User Created!" };
            return Ok();
        }
    }
}
