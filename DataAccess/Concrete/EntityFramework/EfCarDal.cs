using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (DatabaseContext context = new DatabaseContext())
            {

                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.Id
                             join x in context.Colors
                             on p.ColorId equals x.Id
                             select new CarDetailDto
                             {
                                 CarName = p.Name, BrandName = c.Name, ColorName = x.Name, DailyPrice = p.DailyPrice, Id = p.Id
                             };
                return result.ToList();

            }
            
        }
    }
}
