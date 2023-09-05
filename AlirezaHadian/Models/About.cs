using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AlirezaHadian.Models
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        [Display(Name ="متن")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Text { get; set; }
        [Display(Name = "فایل رزومه")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string CVFile { get; set; }
        [Display(Name ="تصویر")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Image { get; set; }
        [ValidateNever]
        public List<AboutInfo> AboutInfos { get; set; }  
    }
}
