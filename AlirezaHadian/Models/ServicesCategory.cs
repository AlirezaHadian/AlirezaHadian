using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class ServicesCategory
    {
        [Key]
        public int ServicesCategoryID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string ServicesCategoryTitle { get; set; }
        [Display(Name = "آیکون")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string ServicesCategoryIcon { get; set; }

        public List<Service> Services { get; set; } 
    }
}
