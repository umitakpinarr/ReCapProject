using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult Add(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int Id);
        IDataResult<Car> GetCarsByBrandId(int Id);
        IDataResult<Car> GetCarsByColorId(int Id);
    }
}
