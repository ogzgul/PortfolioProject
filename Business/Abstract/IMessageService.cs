using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<List<Message>> GetAll();
        IResult GetById(int messageId);
        IResult Add(Message message);
        IResult Update(Message message);
        IResult Delete(int id);
    }
}
