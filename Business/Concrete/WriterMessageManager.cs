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
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writerMessageDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;
        }

        public IResult Add(WriterMessage writerMessage)
        {
            _writerMessageDal.Add(writerMessage);
            return new SuccessResult(Messages.WriterMessageAdded);
        }

        public IResult Delete(int id)
        {
            var deletedWriterMessage = _writerMessageDal.Get(x => x.WriterMessageID == id);
            _writerMessageDal.Delete(deletedWriterMessage);
            return new SuccessResult($"Deleted writerMessage: {id} number's {Messages.WriterMessageDeleted}");
        }

        public IDataResult<List<WriterMessage>> GetAll()
        {
            var listedWriterMessage = _writerMessageDal.GetAll();
            return new SuccessDataResult<List<WriterMessage>>(listedWriterMessage, Messages.WriterMessageGetAll);
        }

        public IDataResult<WriterMessage> GetById(int writerMessageId)
        {
            var listWriterMessageGetById = _writerMessageDal.Get(x => x.WriterMessageID == writerMessageId);
            return new SuccessDataResult<WriterMessage>(listWriterMessageGetById, Messages.WriterMessageGetById);
        }

        public IResult Update(WriterMessage writerMessage)
        {
            var updateWriterMessage = _writerMessageDal.Get(x => x.WriterMessageID == writerMessage.WriterMessageID);
            WriterMessage updatedWriterMessage = new WriterMessage()
            {
                WriterMessageID = writerMessage.WriterMessageID,
                Content = writerMessage.Content,
                Date = writerMessage.Date,
                Receiver = writerMessage.Receiver,
                Sender = writerMessage.Sender,
                Subject = writerMessage.Subject
            };
            _writerMessageDal.Update(updatedWriterMessage);
            return new SuccessResult(Messages.WriterMessageUpdated);
        }
    }
}
