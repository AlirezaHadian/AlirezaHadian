using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Count { get; set; }
        public About About { get; set; }
    }
}
