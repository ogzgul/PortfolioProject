using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetById(int aboutId);
        IResult Add(About about);
        IResult Update(About about);
        IResult Delete(int id);
    }
}
