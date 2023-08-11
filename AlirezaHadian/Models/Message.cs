using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage ="{0} اجباری می باشد")]
        public string Name { get; set; }
        [Display(Name= "شماره موبایل / ایمیل")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [RegularExpression(@"^([+]?\d{1,2}[-\s]?|)\d{3}[-\s]?\d{3}[-\s]?\d{4}|^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)", ErrorMessage = "{0} معتبر نمی باشد!")]
        public string EmailOrPhone { get; set; }
        [Display(Name = "پروژه")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Prject { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string MessageText { get; set; }
        [Display(Name = "تاریخ پیام")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public DateTime MessageTime { get; set; } = DateTime.Now;
    }
}
