using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage ="{0} اجباری می باشد")]
        [MaxLength(200, ErrorMessage ="{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "عنوان فرعی")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(200, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string SubTitle { get; set; }
        [Display(Name = "تصویر اصلی")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Image { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Link { get; set; }

        public List<PortfolioImageGallery> PortfolioImages { get; set; }
    }
}
