using Microsoft.AspNetCore.Http;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PictureURL { get; set; }
        public IFormFile Picture { get; set; }
    }
}
