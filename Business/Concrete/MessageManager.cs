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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Delete(int id)
        {
            var deletedMessage = _messageDal.Get(x => x.MessageID == id);
            return new SuccessResult($"Deleted message: {id} number's {Messages.MessageDeleted}");
        }

        public IDataResult<List<Message>> GetAll()
        {
            var listedMessage = _messageDal.GetAll();
            return new SuccessDataResult<List<Message>>(listedMessage, Messages.MessageGetAll);
        }

        public IResult GetById(int messageId)
        {
            var listMessageGetById = _messageDal.Get(x => x.MessageID == messageId);
            return new SuccessDataResult<Message>(listMessageGetById, Messages.MessageGetById);
        }

        public IResult Update(Message message)
        {
            var updateMessage = _messageDal.Get(x => x.MessageID == message.MessageID);
            Message updatedMessage = new Message()
            {
                MessageID = message.MessageID,
                Content = message.Content,
                Date = message.Date,
                Mail = message.Mail,
                Name = message.Name,
                Status = message.Status
            };
            _messageDal.Update(updatedMessage);
            return new SuccessResult(Messages.MessageUpdated);
        }
    }
}
