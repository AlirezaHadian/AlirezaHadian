using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class HomeSocial
    {
        [Key]
        public int HomeSocialID { get; set; }
        [Display(Name = "آیکون")][Required(ErrorMessage ="{0} اجباری می باشد")]
        public string SocialIcon { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string SocialLink { get; set; }
    }
}
