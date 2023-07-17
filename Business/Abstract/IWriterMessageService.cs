using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterMessageService
    {
        IDataResult<List<WriterMessage>> GetAll();
        IDataResult<WriterMessage> GetById(int writerMessageId);
        IResult Add(WriterMessage writerMessage);
        IResult Update(WriterMessage writerMessage);
        IResult Delete(int id);
    }
}
