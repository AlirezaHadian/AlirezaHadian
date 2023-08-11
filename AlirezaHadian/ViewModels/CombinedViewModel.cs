using AlirezaHadian.Models;
using Microsoft.EntityFrameworkCore;

namespace AlirezaHadian.ViewModels
{
    public class CombinedViewModel
    {
        public IEnumerable<About> Abouts { get; set; }
        public IEnumerable<AboutInfo> AboutInfos { get; set; }
        public IEnumerable<Certificate> Certificates { get; set; }
        public IEnumerable< ContactUs > ContactUs { get; set; }
        public IEnumerable< FooterSocial > FooterSocials { get; set; }
        public IEnumerable<Home> Home { get; set; }
        public IEnumerable<HomeSocial> HomeSocials { get; set; }
        public IEnumerable<JourneyTimeline> JourneyTimelines { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public IEnumerable<PortfolioImageGallery> ImageGalleries { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<ServicesCategory> ServicesCategories { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<SkillsCategory> SkillsCategories { get; set; }
        public MessageViewModel message { get; set; }
    }
}
