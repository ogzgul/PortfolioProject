using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult(Messages.AboutAdded);
        }

        public IResult Delete(int id)
        {
            var deletedAbout = _aboutDal.Get(x => x.AboutID == id);
            _aboutDal.Delete(deletedAbout);
            return new SuccessResult($"Deleted about: {id} number's {Messages.AboutDeleted}");
        }

        public IDataResult<List<About>> GetAll()
        {
            var listedAbout=_aboutDal.GetAll();
            return new SuccessDataResult<List<About>>(listedAbout, Messages.AboutGetAll);
        }

        public IDataResult<About> GetById(int aboutId)
        {
            var listAboutGetById = _aboutDal.Get(x => x.AboutID == aboutId);
            return new SuccessDataResult<About>(listAboutGetById, Messages.AboutGetById);
        }

        public IResult Update(About about)
        {
            var updateAbout = _aboutDal.Get(x=>x.AboutID==about.AboutID);
            About updatedAbout = new About()
            {
                AboutID = about.AboutID,
                Address = about.Address,
                Age = about.Age,
                Description = about.Description,
                ImageUrl = about.ImageUrl,
                Mail = about.Mail,
                Phone = about.Phone,
                Title = about.Title
            };
            _aboutDal.Update(updatedAbout);
            return new SuccessResult(Messages.AboutUpdated);
        }
    }
}
