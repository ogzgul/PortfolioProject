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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            return new SuccessResult(Messages.TestimonialAdded);
        }

        public IResult Delete(int id)
        {
            var deletedTestimonial = _testimonialDal.Get(x => x.TestimonialID == id);
            return new SuccessResult($"Deleted testimonial: {id} number's {Messages.TestimonialDeleted}");
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            var listedTestimonial = _testimonialDal.GetAll();
            return new SuccessDataResult<List<Testimonial>>(listedTestimonial, Messages.TestimonialGetAll);
        }

        public IResult GetById(int testimonialId)
        {
            var listTestimonialGetById = _testimonialDal.Get(x => x.TestimonialID == testimonialId);
            return new SuccessDataResult<Testimonial>(listTestimonialGetById, Messages.TestimonialGetById);
        }

        public IResult Update(Testimonial testimonial)
        {
            var updateTestimonial = _testimonialDal.Get(x => x.TestimonialID == testimonial.TestimonialID);
            Testimonial updatedTestimonial = new Testimonial()
            {
                TestimonialID = testimonial.TestimonialID,
                ClientName=testimonial.ClientName,
                Comment=testimonial.Comment,
                Company=testimonial.Company,
                ImageUrl=testimonial.ImageUrl
            };
            _testimonialDal.Update(updatedTestimonial);
            return new SuccessResult(Messages.TestimonialUpdated);
        }
    }
}
