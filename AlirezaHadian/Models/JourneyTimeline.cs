using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class JourneyTimeline
    {
        [Key]
        public int JourneyID { get; set; }
        [Display(Name = "عنوان")][Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage ="{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "عنوان فرعی")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(350, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string SubTitle { get; set; }
        [Display(Name = "تاریخ شروع - پایان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(300, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string FromToEndDate { get; set; }
    }
}
