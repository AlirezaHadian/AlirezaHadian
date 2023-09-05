using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Display(Name = "متن")][Required(ErrorMessage = "{0} اجباری می باشد")][MaxLength(250, ErrorMessage ="{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Text { get; set; }
        [Display(Name = "دسته")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public int ServicesCategoryID { get; set; }
        [ValidateNever]
        public ServicesCategory ServicesCategory { get; set; }
    }
}
