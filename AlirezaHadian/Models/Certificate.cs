using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateID { get; set; }
        [Display(Name = "عنوان")][Required(ErrorMessage ="{0} اجباری می باشد")][MaxLength(150, ErrorMessage ="{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [ValidateNever]
        public string Image { get; set; }
    }
}
