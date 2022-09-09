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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccessResult("Başarılı Bir Şekilde Kaydedildi.");
           
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Başarılı Bir Şekilde Silindi.");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Başarılı Bir Şekilde Listelendi.");
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Başarılı Bir Şekilde Eklendi.");
        }
    }
}
