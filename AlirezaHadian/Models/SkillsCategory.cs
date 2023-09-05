using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class SkillsCategory
    {
        [Key]
        public int SkillCategoryID { get; set; }
        [Display(Name = "عنوان دسته")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [MaxLength(200, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string SkillCategoryTitle { get; set; }
        [Display(Name = "توضیح دسته")]
        [MaxLength(300, ErrorMessage = "{0}  نمی تواند بیش از {1} کاراکتر باشد")]
        public string? SkillCategorySubTitle { get; set; }
        [Display(Name = "آیکون دسته")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string SkillCategoryIcon { get; set; }
        [ValidateNever]
        public List<Skill> Skills { get; set; }
    }
}
