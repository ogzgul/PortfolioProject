using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IDataResult<List<Testimonial>> GetAll();
        IResult GetById(int testimonialId);
        IResult Add(Testimonial testimonial);
        IResult Update(Testimonial testimonial);
        IResult Delete(int id);
    }
}
