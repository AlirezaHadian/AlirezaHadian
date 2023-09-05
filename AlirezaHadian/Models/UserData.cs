using System.ComponentModel.DataAnnotations;

namespace AlirezaHadian.Models
{
    public class UserData
    {
        [Key]
        public int UserDataID { get; set; }
        [Display(Name = "عامل کاربر")]
        public string UserAgent { get; set; }
        [Display(Name = "آی پی کاربر")]
        public string IPAddress { get; set; }
        [Display(Name = "ارسال از وب سایت")]
        public string Referrer { get; set; }
        [Display(Name = "سیستم عامل")]
        public string OperatingSystem { get; set; }
        [Display(Name = "مشخصات دستگاه")]
        public string DeviceSpecifications { get; set; }
        [Display(Name = "زمان درخواست")]
        public DateTime RequestTime { get; set; }
        [Display(Name = "زبان مرورگر")]
        public string BrowserLanguage { get; set; }
    }
}
