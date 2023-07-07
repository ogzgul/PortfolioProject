using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureService
    {
        IDataResult<List<Feature>> GetAll();
        IResult GetById(int featureId);
        IResult Add(Feature feature);
        IResult Update(Feature feature);
        IResult Delete(int id);
    }
}
