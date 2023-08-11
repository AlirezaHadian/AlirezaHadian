using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AlirezaHadian.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "درصد")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [Range(0, 100, ErrorMessage = "درصد باید از بین ۰ تا ۱۰۰ باشد")]
        public int Percentage { get; set; }
        [Display(Name = "دسته")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public int SkillCategoryID { get; set; }
        [ForeignKey("SkillCategoryID")]
        public SkillsCategory SkillsCategory { get; set; }
    }
}
