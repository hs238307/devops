using Car.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_rental_project.Interface
{
    public interface CarInterface
    {
        public List<Cars> GetAllCars();
        public Task AddToRental(int carId, int days, int userId);
        public Task UpdateToRental(int rentalId, int days, int userId);
        public bool IsRequestForReturn(int rentalId, int userId);
        public bool IsUsersRentalCar(int userId, int rentalId);
        public bool IsCarExists(int carId);
        public bool IsRental(int rentalId);
        public List<Rent> GetAllRentalCars();
        public List<Rent> GetAllRentalCarsByUserId(int userId);
        public Task AddCar(Cars car);
        public Task EditCar(Cars car);
        public Cars GetCarById(int id);
        public Task DeleteCar(int id);
        public Task DeleteRentalCar(int id);
        public Task RequestReturn(int rentalId, int userId);
        public bool RequestReturnExist(int rentalId, int userId);
        public Task ApproveReturnRequest(int rentalId, int userId);
        public List<Rent> GetAllReturnRequest();
    }
}
