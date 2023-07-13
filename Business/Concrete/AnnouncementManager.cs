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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public IResult Add(Announcement announcement)
        {
            _announcementDal.Add(announcement);
            return new SuccessResult(Messages.AnnouncementAdded);
        }

        public IResult Delete(int id)
        {
            var deletedAnnouncement = _announcementDal.Get(x => x.AnnouncementID == id);
            _announcementDal.Delete(deletedAnnouncement);
            return new SuccessResult($"Deleted announcement: {id} number's {Messages.AnnouncementDeleted}");
        }

        public IDataResult<List<Announcement>> GetAll()
        {
            var listedAnnouncement = _announcementDal.GetAll();
            return new SuccessDataResult<List<Announcement>>(listedAnnouncement, Messages.AnnouncementGetAll);
        }

        public IDataResult<Announcement> GetById(int announcementId)
        {
            var listAnnouncementGetById = _announcementDal.Get(x => x.AnnouncementID == announcementId);
            return new SuccessDataResult<Announcement>(listAnnouncementGetById, Messages.AnnouncementGetById);
        }

        public IResult Update(Announcement announcement)
        {
            var updateAnnouncement = _announcementDal.Get(x => x.AnnouncementID == announcement.AnnouncementID);
            Announcement updatedAnnouncement = new Announcement()
            {
               AnnouncementID=announcement.AnnouncementID,
               Content=announcement.Content,
               Date=announcement.Date,
               Status= announcement.Status,
               Title= announcement.Title
            };
            _announcementDal.Update(updatedAnnouncement);
            return new SuccessResult(Messages.AboutUpdated);
        }
    }
}
