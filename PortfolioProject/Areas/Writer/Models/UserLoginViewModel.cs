using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz...")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi Giriniz...")]
        public string Password { get; set; }
    }
}
