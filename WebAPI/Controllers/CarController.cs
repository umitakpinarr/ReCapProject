using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        //Hata Kodları : tr.wikipedia.org/wiki/HTTP_durum_kodlar%C4%B1

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(car);
            return Ok(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(id);
            return Ok(result);
        }
    }
}
