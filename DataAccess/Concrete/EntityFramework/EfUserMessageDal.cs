using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserMessageDal : EfEntityRepositoryBase<UserMessage, PortfolioContext>, IUserMessageDal
    {
        public List<UserMessage> GetUserMessagesWithUser()
        {
            using (var c = new PortfolioContext())
            {
                return c.UserMessages.Include(x => x.User).ToList();
            }
            
        }
    }
}
