using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        IDataResult<List<Experience>> GetAll();
        IResult GetById(int experienceId);
        IResult Add(Experience experience);
        IResult Update(Experience experience);
        IResult Delete(int id);
    }
}
