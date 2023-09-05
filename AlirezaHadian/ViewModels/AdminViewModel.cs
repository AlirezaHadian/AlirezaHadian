using AlirezaHadian.Models;

namespace AlirezaHadian.ViewModels
{
    public class AdminHomeViewModel
    {
        public Home Home { get; set; }
        public IEnumerable<HomeSocial> HomeSocials { get; set; }
    }
    public class AdminAboutViewModel
    {
        public About about { get; set; }
        public IEnumerable<AboutInfo> aboutInfo { get; set; }
    }
    public class AdminSkillViewModel
    {
        public IEnumerable<SkillsCategory> categories { get; set; }
        public IEnumerable<Skill> skill { get; set; }
    }

    public class AdminServicesViewModel
    {
        public IEnumerable<ServicesCategory> serviceCategories { get; set; }
        public IEnumerable<Service> services { get; set; }
    }

    public class AdminIndexViewModel
    {
        public int TodayVisit { get; set; }
        public IEnumerable<UserData> userData { get; set; }
        public IEnumerable<TelegramBotInfo> botInfo { get; set; }
    }

}
