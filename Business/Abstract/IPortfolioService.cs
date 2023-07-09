using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        IDataResult<List<Portfolio>> GetAll();
        IDataResult<Portfolio> GetById(int portfolioId);
        IResult Add(Portfolio portfolio);
        IResult Update(Portfolio portfolio);
        IResult Delete(int id);
    }
}
