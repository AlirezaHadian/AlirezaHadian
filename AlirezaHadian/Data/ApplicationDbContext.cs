using AlirezaHadian.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AlirezaHadian.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutInfo> AboutInfos { get; set; }
        public DbSet<Certificate> Certificates{ get; set; }
        public DbSet<ContactUs> ContactUs{ get; set; }
        public DbSet<FooterSocial> FooterSocials { get; set; }
        public DbSet<Home> Home{ get; set; }
        public DbSet<HomeSocial> HomeSocials{ get; set; }
        public DbSet<JourneyTimeline> JourneyTimelines{ get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicesCategory> ServicesCategories{ get; set; }
        public DbSet<Skill> Skills{ get; set; }
        public DbSet<SkillsCategory> SkillsCategories { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<TelegramBotInfo> TelegramBotInfos { get; set; }
    }
}
