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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
           return new SuccessResult("Başarılı Bir Şekilde Eklendi.");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Başarılı Bir Şekilde Silindi.");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Başarılı Bİr Şekilde Listelendi");
        }

        public IDataResult<Brand> GetById(int Id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == Id));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult("Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
