using Linkedin.DbContext;
using LinkedIn.Core.Managers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Core
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext context;
        public UnitOfWork(IOwinContext owinContext)
        {
            context = owinContext.Get<ApplicationDbContext>();
            ApplicationUserManager = owinContext.Get<ApplicationUserManager>();
            ApplicationSignInManager = owinContext.Get<ApplicationSignInManager>();
        }
        public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> options, IOwinContext owinContext)
        {
            return new UnitOfWork(owinContext);
        }

        public ApplicationUserManager ApplicationUserManager { get; }
        public ApplicationSignInManager ApplicationSignInManager { get; }
        public AwardManager AwardManager
        {
            get
            {
                return AwardManager.GetInstance(context);
            }
        }

        public CommentManager CommentManager
        {
            get
            {
                return CommentManager.GetInstance(context);
            }
        }
        public CourseManager CourseManager
        {
            get
            {
                return CourseManager.GetInstance(context);
            }
        }
        public EducationExperienceManager EducationExperienceManager
        {
            get
            {
                return EducationExperienceManager.GetInstance(context);
            }
        }
        public LanguageManager LanguageManager
        {
            get
            {
                return LanguageManager.GetInstance(context);
            }
        }
        public PatentManager PatentManager
        {
            get
            {
                return PatentManager.GetInstance(context);
            }
        }

        public PostManager PostManager
        {
            get
            {
                return PostManager.GetInstance(context);
            }
        }
        public ProjectManager ProjectManager
        {
            get
            {
                return ProjectManager.GetInstance(context);
            }
        }
        public PublicationManager PublicationManager
        {
            get
            {
                return PublicationManager.GetInstance(context);
            }
        }
        public SavedPlaceManager SavedPlaceManager
        {
            get
            {
                return SavedPlaceManager.GetInstance(context);
            }
        }
        public SkillManager SkillManager
        {
            get
            {
                return SkillManager.GetInstance(context);
            }
        }

        public TestScoreManager TestScoreManager
        {
            get
            {
                return TestScoreManager.GetInstance(context);
            }
        }

        public VolunteerExperienceManager VolunteerExperienceManager
        {
            get
            {
                return VolunteerExperienceManager.GetInstance(context);
            }
        }

        public WorkExperienceManager WorkExperienceManager
        {
            get
            {
                return WorkExperienceManager.GetInstance(context);
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
