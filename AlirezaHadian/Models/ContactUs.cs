using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    [Keyless]
    public class ContactUs
    {
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(20, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string PhoneNumber { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(200, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]

        public string Email { get; set; }
        [Display(Name = "مکان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(300, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Place { get; set; }
    }
}
