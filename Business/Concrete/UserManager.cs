using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int id)
        {
            var deletedUser = _userDal.Get(x => x.UserID == id);
            _userDal.Delete(deletedUser);
            return new SuccessResult($"Deleted user: {id} number's {Messages.UserDeleted}");
        }

        public IDataResult<List<User>> GetAll()
        {
            var listedUser = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(listedUser, Messages.UserGetAll);
        }

        public IDataResult<User> GetById(int userId)
        {
            var listUserGetById = _userDal.Get(x => x.UserID == userId);
            return new SuccessDataResult<User>(listUserGetById, Messages.UserGetById);
        }

        public IResult Update(User user)
        {
            var updateUser = _userDal.Get(x => x.UserID == user.UserID);
            User updatedUser = new User()
            {
               UserID=user.UserID,
               Name=user.Name,
               Surname=user.Surname,
               UserName=user.UserName,
               Mail=user.Mail,
               Password= user.Password,
               ImageURL=user.ImageURL,
               Status=user.Status
            };
            _userDal.Update(updatedUser);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
