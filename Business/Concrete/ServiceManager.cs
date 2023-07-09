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
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IResult Add(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult(Messages.ServiceAdded);
        }

        public IResult Delete(int id)
        {
            var deletedService = _serviceDal.Get(x => x.ServiceID == id);
            _serviceDal.Delete(deletedService);
            return new SuccessResult($"Deleted service: {id} number's {Messages.ServiceDeleted}");
        }

        public IDataResult<List<Service>> GetAll()
        {
            var listedService = _serviceDal.GetAll();
            return new SuccessDataResult<List<Service>>(listedService, Messages.ServiceGetAll);
        }

        public IResult GetById(int serviceId)
        {
            var listServiceGetById = _serviceDal.Get(x => x.ServiceID == serviceId);
            return new SuccessDataResult<Service>(listServiceGetById, Messages.ServiceGetById);
        }

        public IResult Update(Service service)
        {
            var updateService = _serviceDal.Get(x => x.ServiceID == service.ServiceID);
            Service updatedService = new Service()
            {
                ServiceID = service.ServiceID,
                Title = service.Title,
                ImageUrl = service.ImageUrl
            };
            _serviceDal.Update(updatedService);
            return new SuccessResult(Messages.ServiceUpdated);
        }
    }
}
