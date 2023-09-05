using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlirezaHadian.Models
{
    public class TelegramBotInfo
    {
        [Key]
        public int UserDataID { get; set; }
        [Display(Name = "آی پی کاربر")]
        public string IPAddress { get; set; }
        [Display(Name = "سیستم عامل")]
        public string OperatingSystem { get; set; }
        [Display(Name = "مشخصات دستگاه")]
        public string DeviceSpecifications { get; set; }
        [Display(Name = "زمان درخواست")]
        public DateTime RequestTime { get; set; }
    }
}
