using AlirezaHadian.Data;
using AlirezaHadian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlirezaHadian
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        private GenericRepository<About> aboutRepostory;
        private GenericRepository<AboutInfo> aboutInfoRepository;
        private GenericRepository<Certificate> certificateRepository;
        private GenericRepository<ContactUs> contactUsRepository;
        private GenericRepository<FooterSocial> footerSocialRepository;
        private GenericRepository<Home> homeRepository;
        private GenericRepository<HomeSocial> homeSocialsRepository;
        private GenericRepository<PortfolioImageGallery> imageGalleryRepository;
        private GenericRepository<JourneyTimeline> journyRepository;
        private GenericRepository<Message> messageRepository;
        private GenericRepository<Portfolio> portfolioRepository;
        private GenericRepository<Service> serviceRepository;
        private GenericRepository<ServicesCategory> servicesCategoryRepository;
        private GenericRepository<Skill> skillRepository;
        private GenericRepository<SkillsCategory> skillsCategoryRepository;



        public GenericRepository<About> AboutRepostory
        {
            get
            {
                if (aboutRepostory == null)
                {
                    aboutRepostory = new GenericRepository<About>(_db);
                }

                return aboutRepostory;
            }
        }
        public GenericRepository<AboutInfo> AboutInfoRepository
        {
            get
            {
                if (aboutInfoRepository == null)
                {
                    aboutInfoRepository = new GenericRepository<AboutInfo>(_db);
                }

                return aboutInfoRepository;
            }
        }
        public GenericRepository<Certificate> CertificateRepository
        {
            get
            {
                if (certificateRepository == null)
                {
                    certificateRepository = new GenericRepository<Certificate>(_db);
                }

                return certificateRepository;
            }
        }
        public GenericRepository<ContactUs> ContactUsRepository
        {
            get
            {
                if (contactUsRepository == null)
                {
                    contactUsRepository = new GenericRepository<ContactUs>(_db);
                }

                return contactUsRepository;
            }
        }
        public GenericRepository<FooterSocial> FooterSocialRepository
        {
            get
            {
                if (footerSocialRepository == null)
                {
                    footerSocialRepository = new GenericRepository<FooterSocial>(_db);
                }

                return footerSocialRepository;
            }
        }
        public GenericRepository<Home> HomeRepository
        {
            get
            {
                if (homeRepository == null)
                {
                    homeRepository = new GenericRepository<Home>(_db);
                }

                return homeRepository;
            }
        }
        public GenericRepository<HomeSocial> HomeSocialRepository
        {
            get
            {
                if (homeSocialsRepository == null)
                {
                    homeSocialsRepository = new GenericRepository<HomeSocial>(_db);
                }

                return homeSocialsRepository;
            }
        }
        public GenericRepository<PortfolioImageGallery> PortfolioImageGalleryRepository
        {
            get
            {
                if (imageGalleryRepository == null)
                {
                    imageGalleryRepository = new GenericRepository<PortfolioImageGallery>(_db);
                }

                return imageGalleryRepository;
            }
        }
        public GenericRepository<JourneyTimeline> JourneyTimelineRepository
        {
            get
            {
                if (journyRepository == null)
                {
                    journyRepository = new GenericRepository<JourneyTimeline>(_db);
                }

                return journyRepository;
            }
        }
        public GenericRepository<Message> MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new GenericRepository<Message>(_db);
                }

                return messageRepository;
            }
        }
        public GenericRepository<Portfolio> PortfolioRepository
        {
            get
            {
                if (portfolioRepository == null)
                {
                    portfolioRepository = new GenericRepository<Portfolio>(_db);
                }

                return portfolioRepository;
            }
        }
        public GenericRepository<Service> ServiceRepository
        {
            get
            {
                if (serviceRepository == null)
                {
                    serviceRepository = new GenericRepository<Service>(_db);
                }

                return serviceRepository;
            }
        }
        public GenericRepository<ServicesCategory> ServicesCategoryRepository
        {
            get
            {
                if (servicesCategoryRepository == null)
                {
                    servicesCategoryRepository = new GenericRepository<ServicesCategory>(_db);
                }

                return servicesCategoryRepository;
            }
        }
        public GenericRepository<Skill> SkillRepository
        {
            get
            {
                if (skillRepository == null)
                {
                    skillRepository = new GenericRepository<Skill>(_db);
                }

                return skillRepository;
            }
        }
        public GenericRepository<SkillsCategory> SkillsCategoryRepository
        {
            get
            {
                if (skillsCategoryRepository == null)
                {
                    skillsCategoryRepository = new GenericRepository<SkillsCategory>(_db);
                }

                return skillsCategoryRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
