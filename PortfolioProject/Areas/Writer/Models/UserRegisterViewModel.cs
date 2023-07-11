using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Resim URL Değeri Giriniz.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lütfen Adını Giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soy Adınızı Giriniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz.")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Giriniz.")]
        public string Mail { get; set; }
    }
}
