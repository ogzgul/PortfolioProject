using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISocialMediaService
    {
        IDataResult<List<SocialMedia>> GetAll();
        IResult GetById(int socialMediaId);
        IResult Add(SocialMedia socialMedia);
        IResult Update(SocialMedia socialMedia);
        IResult Delete(int id);
    }
}
