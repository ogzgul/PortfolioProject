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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public IResult Add(Experience experience)
        {
            _experienceDal.Add(experience);
            return new SuccessResult(Messages.ExperienceAdded);
        }

        public IResult Delete(int id)
        {
            var deletedExperience = _experienceDal.Get(x => x.ExperienceID == id);
            _experienceDal.Delete(deletedExperience);
            return new SuccessResult($"Deleted experience: {id} number's {Messages.ExperienceDeleted}");
        }

        public IDataResult<List<Experience>> GetAll()
        {
            var listedExperience = _experienceDal.GetAll();
            return new SuccessDataResult<List<Experience>>(listedExperience, Messages.ExperienceGetAll);
        }

        public IDataResult<Experience> GetById(int experienceId)
        {
            var listExperienceGetById = _experienceDal.Get(x => x.ExperienceID == experienceId);
            return new SuccessDataResult<Experience>(listExperienceGetById, Messages.ExperienceGetById);
        }

        public IResult Update(Experience experience)
        {
            var updateExperience = _experienceDal.Get(x => x.ExperienceID == experience.ExperienceID);
            Experience updatedExperience = new Experience()
            {
                ExperienceID = experience.ExperienceID,
                Date = experience.Date,
                Description = experience.Description,
                ImageUrl = experience.ImageUrl,
                Name = experience.Name
            };
            _experienceDal.Update(updatedExperience);
            return new SuccessResult(Messages.ExperienceUpdated);
        }
    }
}
