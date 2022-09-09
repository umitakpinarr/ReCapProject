using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2 && car.DailyPrice < 0)
            {
                Console.WriteLine("Araç adı en az 2 karakter olmalıdır. Araç günlük fiyatı 0' dan büyük olmalıdır.");
                return new ErrorResult("Araç Eklenemedi.");
                
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araç başarılı bir şekilde eklendi.");
                return new SuccessResult("Başarılı Bir Şekilde Eklendi.");

            }
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Başarılı Bir Şekilde Silindi.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Başarılı Bir Şekilde Listelendi.");
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(),"Araç Detayları Başarılı Şekilde Listelendi.");
        }

        public IDataResult<Car> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.BrandId == Id));
        }

        public IDataResult<Car> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.ColorId == Id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
