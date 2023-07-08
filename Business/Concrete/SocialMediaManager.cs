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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public IResult Add(SocialMedia socialMedia)
        {
            _socialMediaDal.Add(socialMedia);
            return new SuccessResult(Messages.SocialMediaAdded);
        }

        public IResult Delete(int id)
        {
            var deletedSocialMedia = _socialMediaDal.Get(x => x.SocialMediaID == id);
            return new SuccessResult($"Deleted socialMedia: {id} number's {Messages.SocialMediaDeleted}");
        }

        public IDataResult<List<SocialMedia>> GetAll()
        {
            var listedSocialMedia = _socialMediaDal.GetAll();
            return new SuccessDataResult<List<SocialMedia>>(listedSocialMedia, Messages.SocialMediaGetAll);
        }

        public IResult GetById(int socialMediaId)
        {
            var listSocialMediaGetById = _socialMediaDal.Get(x => x.SocialMediaID == socialMediaId);
            return new SuccessDataResult<SocialMedia>(listSocialMediaGetById, Messages.SocialMediaGetById);
        }

        public IResult Update(SocialMedia socialMedia)
        {
            var updateSocialMedia = _socialMediaDal.Get(x => x.SocialMediaID == socialMedia.SocialMediaID);
            SocialMedia updatedSocialMedia = new SocialMedia()
            {
               SocialMediaID=socialMedia.SocialMediaID,
               Icon=socialMedia.Icon,
               Name=socialMedia.Name,
               Status=socialMedia.Status,
               Url=socialMedia.Url
            };
            _socialMediaDal.Update(updatedSocialMedia);
            return new SuccessResult(Messages.SocialMediaUpdated);
        }
    }
}
