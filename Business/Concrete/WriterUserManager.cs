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
    public class WriterUserManager : IWriterUserService
    {
        IWriterUserDal _writerUserDal;

        public WriterUserManager(IWriterUserDal writerUserDal)
        {
            _writerUserDal = writerUserDal;
        }

        public IResult Add(WriterUser writerUser)
        {
            _writerUserDal.Add(writerUser);
            return new SuccessResult(Messages.WriterUserAdded);
        }

        public IResult Delete(int id)
        {
            var deletedWriterUser = _writerUserDal.Get(x => x.Id == id);
            _writerUserDal.Delete(deletedWriterUser);
            return new SuccessResult($"Deleted writeruser: {id} number's {Messages.WriterUserDeleted}");
        }

        public IDataResult<List<WriterUser>> GetAll()
        {
            var listedWriterUser = _writerUserDal.GetAll();
            return new SuccessDataResult<List<WriterUser>>(listedWriterUser, Messages.WriterUserGetAll);
        }

        public IDataResult<WriterUser> GetById(int writerUserId)
        {
            var listWriterUserGetById = _writerUserDal.Get(x => x.Id == writerUserId);
            return new SuccessDataResult<WriterUser>(listWriterUserGetById, Messages.WriterUserGetById);
        }

        public IResult Update(WriterUser writerUser)
        {

            var updateWriterUser = _writerUserDal.Get(x => x.Id == writerUser.Id);
            WriterUser updatedWriterUser = new WriterUser()
            {
               Id=writerUser.Id,
               Name=writerUser.Name,
               Surname=writerUser.Surname,
               Email=writerUser.Email
            };
            _writerUserDal.Update(updatedWriterUser);
            return new SuccessResult(Messages.WriterUserUpdated);
        }
    }
}
