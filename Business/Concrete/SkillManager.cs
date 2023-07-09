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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public IResult Add(Skill skill)
        {
            _skillDal.Add(skill);
            return new SuccessResult(Messages.SkillAdded);
        }

        public IResult Delete(int id)
        {
            var deletedSkill = _skillDal.Get(x => x.SkillID == id);
            _skillDal.Delete(deletedSkill);
            return new SuccessResult($"Deleted skill: {id} number's {Messages.SkillDeleted}");
        }

        public IDataResult<List<Skill>> GetAll()
        {
            var listedSkill = _skillDal.GetAll();
            return new SuccessDataResult<List<Skill>>(listedSkill, Messages.SkillGetAll);
        }

        public IDataResult<Skill> GetById(int skillId)
        {
            var listSkillGetById = _skillDal.Get(x => x.SkillID == skillId);
            return new SuccessDataResult<Skill>(listSkillGetById, Messages.SkillGetById);
        }

        public IResult Update(Skill skill)
        {
            var updateSkill = _skillDal.Get(x => x.SkillID == skill.SkillID);
            Skill updatedSkill = new Skill()
            {
                SkillID = skill.SkillID,
                Title = skill.Title,
                Value = skill.Value
            };
            _skillDal.Update(updatedSkill);
            return new SuccessResult(Messages.SkillUpdated);
        }
    }
}
