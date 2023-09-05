using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace AlirezaHadian.Models
{
    public class AboutInfo
    {
        [Key]
        public int AboutInfoID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Title { get; set; }
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Count { get; set; }
        public int AboutID { get; set; }
        [ForeignKey("AboutID")]
        [ValidateNever]
        public About About { get; set; }
    }
}
