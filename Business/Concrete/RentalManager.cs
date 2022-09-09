using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var checkRent = _rentalDal.Get(p => p.CarId == rental.CarId && p.ReturnDate == null);
            if (checkRent != null)
            {
                return new ErrorResult("Araç Eklenemedi.");
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Başarılı Bir Şekilde Eklendi.");
            }
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Başarılı Bir Şekilde Silindi.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), "Başarılı Bir Şekilde Listelendi.");
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == Id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
