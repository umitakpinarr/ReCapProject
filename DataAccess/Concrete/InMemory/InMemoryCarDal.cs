using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "Bu Araç En İyi Aracımızdır.", ModelYear = 2000},
                new Car{ Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 2000, Description = "Bu Araç En İyi İkinci Aracımızdır.", ModelYear = 2022},
                new Car{ Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 1500, Description = "Bu Araç En İyi Üçüncü Aracımızdır.", ModelYear = 2012},
                new Car{ Id = 4, BrandId = 1, ColorId = 2, DailyPrice = 1800, Description = "Bu Araç En İyi Dördüncü Aracımızdır.", ModelYear = 2010},

            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public Car GetById(int Id)
        {
            return _car.SingleOrDefault(p => p.Id == Id);
        }

        public List<Car> GetAll()
        {
            return _car.ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }
    }
}
