using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class PortfolioImageGallery
    {
        [Key]
        public int ImageGalleryID { get; set; }
        [Display(Name = "نمونه کار")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public int PortfolioID { get; set; }
        [Display(Name = "کپشن")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(100, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Caption { get; set; }
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Image { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
