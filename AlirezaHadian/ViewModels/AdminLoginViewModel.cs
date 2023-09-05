using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlirezaHadian.ViewModels
{
    public class AdminLoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Display(Name = "مرا بخاطر بسپار!")]
        //public bool RemmemberMe { get; set; }
        //public string GoogleCaptchaToken { get; set; }
    }
}
