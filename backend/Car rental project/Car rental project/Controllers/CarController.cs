using Car.Data.Tables;
using Car_rental_project.Interface;
using Car_rental_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public readonly CarInterface _carInterface;
        public readonly AccountInterface _accountInterface;
        public CarController(CarInterface carInterface, AccountInterface accountInterface)
        {
            _carInterface = carInterface;
            _accountInterface = accountInterface;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Cars> cars = _carInterface.GetAllCars();
            List<CarModel> carExports = new List<CarModel>();
            foreach (Cars car in cars)
            {
                CarModel carModel = new CarModel
                {
                    id = car.id,
                    maker = car.maker,
                    model = car.model,
                    price = car.price,
                    image = Convert.ToBase64String(car.image)
                };
                carExports.Add(carModel);
            }
            return Ok(carExports);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            Cars car = _carInterface.GetCarById(id);
            CarModel carModel = new CarModel
            {
                id = car.id,
                maker = car.maker,
                model = car.model,
                price = car.price,
                image = Convert.ToBase64String(car.image)
            };
            return Ok(carModel);
        }

        [HttpGet("data/rent")]
        public IActionResult GetRentedCars()
        {
            List<Rent> rentedcars = _carInterface.GetAllRentalCars();
            List<RentCarModel> rentCarExports = new List<RentCarModel>();
            foreach (Rent rent in rentedcars)
            {
                RentCarModel rentCarModel = new RentCarModel
                {
                    id = rent.id,
                    maker = rent.maker,
                    model = rent.model,
                    price = rent.price,
                    image = Convert.ToBase64String(rent.image),
                    endDate = rent.endDate
                };
                rentCarExports.Add(rentCarModel);
            }
            return Ok(rentCarExports);
        }

        [HttpPost("data/rent/user")]
        public IActionResult GetRentedCar([FromBody] Token model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (isUserAnAdmin)
            {
                var error = new { message = "Only Normal user can add car to rental" };
                return BadRequest(error);
            }
            List<Rent> rentedcars = _carInterface.GetAllRentalCarsByUserId(userId);
            List<RentModel> rentCarExports = new List<RentModel>();
            foreach (Rent rent in rentedcars)
            {
                RentModel rentCarModel = new RentModel
                {
                    id = rent.id,
                    maker = rent.maker,
                    model = rent.model,
                    price = rent.price,
                    image = Convert.ToBase64String(rent.image),
                    endDate = rent.endDate,
                    startDate = rent.startDate,
                    cost = rent.cost,
                    duration = rent.duration
                };
                rentCarExports.Add(rentCarModel);
            }
            return Ok(rentCarExports);
        }

       
        [HttpPost("data/rent/return/{id}")]
        public async Task<IActionResult> RequestRentedCar(int id , [FromBody] Token model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (isUserAnAdmin)
            {
                var error = new { message = "Only Normal user can send request for rental" };
                return BadRequest(error);
            }
            bool isUserOwnRentalCar = _carInterface.IsUsersRentalCar(userId, id);
            if (!isUserOwnRentalCar)
            {
                var error = new { message = "Rental car not belongs to the user" };
                return BadRequest(error);
            }
            bool isAlreadyRequested = _carInterface.RequestReturnExist(id, userId);
            if (isAlreadyRequested)
            {
                var error = new { message = "You already requested"};
                return BadRequest(error);
            }
            await _carInterface.RequestReturn(id, userId);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpPost("data/rent/return/approve/{id}")]
        public async Task<IActionResult> ApproveRentedCar(int id, [FromBody] TokenUserModel model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only Admin can approve rental request" };
                return BadRequest(error);
            }
            bool isRequestExists = _carInterface.IsRequestForReturn(id, model.user);
            if (!isRequestExists)
            {
                var error = new { message = "No return request for this!" };
                return BadRequest(error);
            }
            await _carInterface.ApproveReturnRequest(id, model.user);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpPost("data/rent/return")]
        public IActionResult GetReturnRequest([FromBody] Token model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only Admin can approve rental request" };
                return BadRequest(error);
            }
            List<Rent> rents = _carInterface.GetAllReturnRequest();
            List<RentUserModel> rentCarExports = new List<RentUserModel>();
            foreach (Rent rent in rents)
            {
                RentUserModel rentCarModel = new RentUserModel
                {
                    id = rent.id,
                    maker = rent.maker,
                    model = rent.model,
                    price = rent.price,
                    image = Convert.ToBase64String(rent.image),
                    endDate = rent.endDate,
                    startDate = rent.startDate,
                    cost = rent.cost,
                    duration = rent.duration,
                    username = _accountInterface.GetUser(rent.userId).username,
                    userId = rent.userId
                };
                rentCarExports.Add(rentCarModel);
            }
            return Ok(rentCarExports);
        }

        [HttpPost("add/rental/car/{id}")]
        public async Task<IActionResult> AddRental(int id, [FromBody] UserDaysModel model)
        {
            int userId = model.userId;
            int days = model.days;
            string token = model.token;
            if (days <= 0)
            {
                var error = new { message = "Days can not be 0 or negetive"};
                return BadRequest(error);
            }
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin or not Exist" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (isUserAnAdmin)
            {
                var error = new { message = "Only Normal user can add car to rental" };
                return BadRequest(error);
            }

            bool isProductExist = _carInterface.IsCarExists(id);
            if (!isProductExist)
            {
                var error = new { message = "Car Doesn't Exist" };
                return BadRequest(error);
            }
            await _carInterface.AddToRental(id, days, userId);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCar([FromForm] CarImageModel model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin or not Exist" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only admin can add products" };
                return BadRequest(error);
            }

            if (model.image == null)
            {
                var error = new { message = "Image is required and should be in JPG or PNG format!" };
                return BadRequest(error);
            }

            if (model.maker == "")
            {
                var error = new { message = "Maker field can not be empty!" };
                return BadRequest(error);
            }

            if (model.carModel == "")
            {
                var error = new { message = "Model field can not be empty!" };
                return BadRequest(error);
            }

            if (model.price <= 0)
            {
                var error = new { message = "Price can not be 0 or negative!" };
                return BadRequest(error);
            }
            var memoryStream = new MemoryStream();
            await model.image.CopyToAsync(memoryStream);
            byte[] imageData = memoryStream.ToArray();
            
            Cars car = new Cars
            {
                maker = model.maker,
                model = model.carModel,
                price = model.price,
                image = imageData
            };
            await _carInterface.AddCar(car);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditCar(int id, [FromForm] CarImageModel model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin or not Exist" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only admin can edit products" };
                return BadRequest(error);
            }
        
            bool isCarExist = _carInterface.IsCarExists(id);
            if (!isCarExist)
            {
                var error = new { message = "Car Doesn't Exist" };
                return BadRequest(error);
            }



            if (model.image == null)
            {
                var error = new { message = "Image is required and should be in JPG or PNG format!" };
                return BadRequest(error);
            }

            if (model.maker == "")
            {
                var error = new { message = "Maker field can not be empty!" };
                return BadRequest(error);
            }

            if (model.carModel == "")
            {
                var error = new { message = "Model field can not be empty!" };
                return BadRequest(error);
            }

            if (model.price <= 0)
            {
                var error = new { message = "Price can not be 0 or negative!" };
                return BadRequest(error);
            }

            var memoryStream = new MemoryStream();
            await model.image.CopyToAsync(memoryStream);
            byte[] imageData = memoryStream.ToArray();
        
            Cars car = new Cars
            {
                id = id,
                maker = model.maker,
                model = model.carModel,
                price = model.price,
                image = imageData
            };
            await _carInterface.EditCar(car);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public async  Task<IActionResult>  DeleteCar(int id, [FromBody] Token model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin or not Exist" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only admin can delete products" };
                return BadRequest(error);
            }

            bool isCarExist = _carInterface.IsCarExists(id);
            if (!isCarExist)
            {
                var error = new { message = "Car Doesn't Exist" };
                return BadRequest(error);
            }

            await _carInterface.DeleteCar(id);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpPost("data/rent/all")]
        public IActionResult GetAllRentedCar([FromBody] Token model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only admin can get all the rental cars" };
                return BadRequest(error);
            }
            List<Rent> rentedcars = _carInterface.GetAllRentalCars();
            List<RentModel> rentCarExports = new List<RentModel>();
            foreach (Rent rent in rentedcars)
            {
                RentModel rentCarModel = new RentModel
                {
                    id = rent.id,
                    maker = rent.maker,
                    model = rent.model,
                    price = rent.price,
                    image = Convert.ToBase64String(rent.image),
                    endDate = rent.endDate,
                    startDate = rent.startDate,
                    cost = rent.cost,
                    duration = rent.duration,
                    userId = rent.userId
                };
                rentCarExports.Add(rentCarModel);
            }
            return Ok(rentCarExports);
        }


        [HttpPut("data/rent/update/{id}")]
        public async Task<IActionResult> UpdateRentedCar(int id,[FromBody] UserAdminDaysModel model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only admin can update the rental cars" };
                return BadRequest(error);
            }
            bool isRentalCarExists = _carInterface.IsRental(id);
            if (!isRentalCarExists)
            {
                var error = new { message = "Car is Not Rental" };
                return BadRequest(error);
            }
            if(model.days <= 0)
            {
                var error = new { message = "Days can not be 0 or negative" };
                return BadRequest(error);
            }
            await _carInterface.UpdateToRental(id, model.days, model.user);
            var data = new { message = "Success!" };
            return Ok(data);
        }

        [HttpDelete("data/rent/delete/{id}")]
        public async Task<IActionResult> DeleteRentedCar(int id, [FromBody] Token model)
        {
            int userId = model.userId;
            string token = model.token;
            bool isUserExists = _accountInterface.IsUserExist(userId);
            if (!isUserExists)
            {
                var error = new { message = "User doesn't not Exist" };
                return BadRequest(error);
            }
            bool isUserLoggedIn = _accountInterface.IsTokenExist(userId, token);
            if (!isUserLoggedIn)
            {
                var error = new { message = "User doesn't Loggedin" };
                return BadRequest(error);
            }
            bool isUserAnAdmin = _accountInterface.IsUserAdmin(userId);
            if (!isUserAnAdmin)
            {
                var error = new { message = "Only admin can delete the rental cars" };
                return BadRequest(error);
            }
            bool isRentalCarExists = _carInterface.IsRental(id);
            if (!isRentalCarExists)
            {
                var error = new { message = "Car is Not Rental" };
                return BadRequest(error);
            }

             await _carInterface.DeleteRentalCar(id);
            var data = new { message = "Success!" };
            return Ok(data);
        }
    }
}
