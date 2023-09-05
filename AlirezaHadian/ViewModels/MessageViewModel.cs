using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlirezaHadian.ViewModels
{
    public class MessageViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Name { get; set; }
        [Display(Name = "شماره موبایل / ایمیل")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [RegularExpression(@"^([+]?\d{1,2}[-\s]?|)\d{3}[-\s]?\d{3}[-\s]?\d{4}|^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)", ErrorMessage = "{0} معتبر نمی باشد!")]
        public string EmailOrPhone { get; set; }
        [Display(Name = "پروژه")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Prject { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string MessageText { get; set; }
        public string GoogleCaptchaToken { get; set; }
    }
}
