using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values = _testimonialManager.GetAll().Data;
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var result = _testimonialManager.GetById(id);
            var testimonial = result.Data;
            _testimonialManager.Delete(testimonial.TestimonialID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialManager.Add(testimonial);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var editTestimonial = _testimonialManager.GetById(id).Data;
            return View(editTestimonial);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            _testimonialManager.Update(testimonial);
            return RedirectToAction("Index");
        }
    }
}
