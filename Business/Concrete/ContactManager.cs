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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult(Messages.ContactAdded);
        }

        public IResult Delete(int id)
        {
            var deletedContact = _contactDal.Get(x => x.ContactID == id);
            _contactDal.Delete(deletedContact);
            return new SuccessResult($"Deleted contact: {id} number's {Messages.ContactDeleted}");
        }

        public IDataResult<List<Contact>> GetAll()
        {
            var listedContact = _contactDal.GetAll();
            return new SuccessDataResult<List<Contact>>(listedContact, Messages.ContactGetAll);
        }

        public IDataResult<Contact> GetById(int contactId)
        {
            var listContactGetById = _contactDal.Get(x => x.ContactID == contactId);
            return new SuccessDataResult<Contact>(listContactGetById, Messages.ContactGetById);
        }

        public IResult Update(Contact contact)
        {
            var updateContact = _contactDal.Get(x => x.ContactID == contact.ContactID);
            Contact updatedContact = new Contact()
            {
                ContactID = contact.ContactID,
                Description = contact.Description,
                Mail = contact.Mail,
                Phone = contact.Phone,
                Title = contact.Title,
            };
            _contactDal.Update(updatedContact);
            return new SuccessResult(Messages.ContactUpdated);
        }
    }
}
