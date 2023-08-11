using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlirezaHadian.Models
{
    public class FooterSocial
    {
        [Key]
        public int FooterSocialID { get; set; }
        [Display(Name = "آیکون")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string FooterIcon { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string FooterLink { get; set; }
    }
}
