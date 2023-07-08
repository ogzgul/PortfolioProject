using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var listedTestimonial = _testimonialManager.GetAll().Data;
            return View(listedTestimonial);
        }
    }
}
