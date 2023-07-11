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
    public class UserMessageManager : IUserMessageService
    {
        IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public IResult Add(UserMessage userMessage)
        {
            _userMessageDal.Add(userMessage);
            return new SuccessResult(Messages.UserMessageAdded);
        }

        public IResult Delete(int id)
        {
            var deletedUserMessage = _userMessageDal.Get(x => x.MessageID == id);
            _userMessageDal.Delete(deletedUserMessage);
            return new SuccessResult($"Deleted userMessage: {id} number's {Messages.UserMessageDeleted}");
        }

        public IDataResult<List<UserMessage>> GetAll()
        {
            var listedUserMessage = _userMessageDal.GetAll();
            return new SuccessDataResult<List<UserMessage>>(listedUserMessage, Messages.UserMessageGetAll);
        }

        public IDataResult<UserMessage> GetById(int userMessageId)
        {
            var listUserMessageGetById = _userMessageDal.Get(x => x.MessageID == userMessageId);
            return new SuccessDataResult<UserMessage>(listUserMessageGetById, Messages.UserMessageGetById);
        }

        public List<UserMessage> GetUserMessagesWithUserService()
        {
            return _userMessageDal.GetUserMessagesWithUser();
        }

        public IResult Update(UserMessage userMessage)
        {
            var userMessageUpdate=_userMessageDal.Get(x=>x.MessageID == userMessage.MessageID);
            UserMessage userMessageUpdated = new UserMessage()
            {
                MessageID = userMessage.MessageID,
                Title = userMessage.Title,
                Content = userMessage.Content,
                Date = userMessage.Date,
                Status = userMessage.Status
            };
            _userMessageDal.Update(userMessageUpdated);
            return new SuccessResult(Messages.UserMessageUpdated);
             
        }
    }
}
