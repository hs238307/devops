using Car.Data;
using Car.Data.Tables;
using Car_rental_project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Service
{
    public class CarService : CarInterface
    {
        public readonly AppDbContext _appDbContext;

        public CarService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddCar(Cars car)
        {
            await _appDbContext.Cars.AddAsync(car);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddToRental(int carId, int days, int userId)
        {
            Cars car = _appDbContext.Cars.FirstOrDefault(c => c.id == carId);
            Rent rent = new Rent
            {
                userId = userId,
                image = car.image,
                maker = car.maker,
                model = car.model,
                price = car.price,
                duration = days,
                cost = days * car.price,
                startDate = DateTime.Now,
                endDate = DateTime.Now.AddDays(days)
            };
            await _appDbContext.Rent.AddAsync(rent);
            _appDbContext.Cars.Remove(car);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task ApproveReturnRequest(int rentalId, int userId)
        {
            RequestReturn requestReturn = _appDbContext.RequestReturn.FirstOrDefault(r => r.rentalId == rentalId && r.userId == userId);
            Rent rent = _appDbContext.Rent.FirstOrDefault(r => r.id == requestReturn.rentalId);
            Cars car = new Cars
            {
                image = rent.image,
                maker = rent.maker,
                model = rent.model,
                price = rent.price
            };
            await _appDbContext.Cars.AddAsync(car);
            _appDbContext.Rent.Remove(rent);
            _appDbContext.RequestReturn.Remove(requestReturn);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task  DeleteCar(int id)
        {
            Cars car = _appDbContext.Cars.FirstOrDefault(c => c.id == id);
            _appDbContext.Cars.Remove(car);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteRentalCar(int id)
        {
            Rent rent = _appDbContext.Rent.FirstOrDefault(c => c.id == id);
            Cars car = new Cars
            {
                image = rent.image,
                maker = rent.maker,
                model = rent.model,
                price = rent.price
            };
            await _appDbContext.Cars.AddAsync(car);
            _appDbContext.Rent.Remove(rent);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditCar(Cars car)
        {
            Cars cars = _appDbContext.Cars.FirstOrDefault(c => c.id == car.id);
            cars.image = car.image;
            cars.maker = car.maker;
            cars.model = car.model;
            cars.price = car.price;
            await _appDbContext.SaveChangesAsync();
        }

        public List<Cars> GetAllCars()
        {
            List<Cars> cars = _appDbContext.Cars.ToList();
            return cars;
        }

        public List<Rent> GetAllRentalCars()
        {
            List<Rent> rents = _appDbContext.Rent.ToList();
            return rents;
        }

        public List<Rent> GetAllRentalCarsByUserId(int userId)
        {
            List<Rent> rents = _appDbContext.Rent.Where(u=>u.userId == userId).ToList();
            return rents;
        }

        public List<Rent> GetAllReturnRequest()
        {
            List<RequestReturn> requests = _appDbContext.RequestReturn.ToList();
            List<Rent> rents = new List<Rent>();
            foreach(RequestReturn r in requests)
            {
                Rent rent = _appDbContext.Rent.FirstOrDefault(re => re.id == r.rentalId && re.userId == r.userId);
                rents.Add(rent);
            }
            return rents;
        }

        public Cars GetCarById(int id)
        {
            Cars car = _appDbContext.Cars.FirstOrDefault(c => c.id == id);
            return car;
        }

        public bool IsCarExists(int carId)
        {
            Cars car = _appDbContext.Cars.FirstOrDefault(c => c.id == carId);
            return car != null;
        }

        public bool IsRental(int rentalId)
        {
            Rent rent = _appDbContext.Rent.FirstOrDefault(r => r.id == rentalId);
            return rent != null;
        }

        public bool IsRequestForReturn(int rentalId, int userId)
        {
            RequestReturn requestReturn = _appDbContext.RequestReturn.FirstOrDefault(r => r.rentalId == rentalId && r.userId == userId);
            if (requestReturn == null)
            {
                return false;
            }
            return true;
        }

        public bool IsUsersRentalCar(int userId, int rentalId)
        {
            Rent rent = _appDbContext.Rent.FirstOrDefault(r => r.id == rentalId && r.userId == userId);
            return rent != null;
        }


        public async Task RequestReturn(int rentalId, int userId)
        {
            RequestReturn requrestReturn = new RequestReturn
            {
                rentalId = rentalId,
                userId = userId
            };
            await _appDbContext.RequestReturn.AddAsync(requrestReturn);
            await _appDbContext.SaveChangesAsync();
        }

        public bool RequestReturnExist(int rentalId, int userId)
        {
            RequestReturn requrestReturn = _appDbContext.RequestReturn.FirstOrDefault(r => r.rentalId == rentalId && r.userId == userId);
            if (requrestReturn==null) return false;
            return true;
        }

        public async Task UpdateToRental(int rentalId, int days, int userId)
        {
            Rent rent = _appDbContext.Rent.FirstOrDefault(r => r.id == rentalId && r.userId == userId);
            rent.duration = days;
            rent.cost = days * rent.price;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
