using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserMessageService
    {
        IDataResult<List<UserMessage>> GetAll();
        IDataResult<UserMessage> GetById(int userMessageId);
        IResult Add(UserMessage userMessage);
        IResult Update(UserMessage userMessage);
        IResult Delete(int id);

        List<UserMessage> GetUserMessagesWithUserService();
    }
}
