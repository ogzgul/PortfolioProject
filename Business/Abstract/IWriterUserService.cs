using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterUserService
    {
        IDataResult<List<WriterUser>> GetAll();
        IDataResult<WriterUser> GetById(int writerUserId);
        IResult Add(WriterUser writerUser);
        IResult Update(WriterUser writerUser);
        IResult Delete(int id);
    }
}
