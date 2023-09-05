using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(50, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "زیر عنوان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(150, ErrorMessage ="{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Subtitle { get; set; }
        [Display(Name = "توضیح")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Description { get; set; }
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Image { get; set; }
    }
}
