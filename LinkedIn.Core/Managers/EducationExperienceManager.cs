using Linkedin.DbContext;
using Linkedin.Models.Entites;
using LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Core.Managers
{
    public class EducationExperienceManager : Repository<EducationExperience, ApplicationDbContext>
    {
        private static EducationExperienceManager Instance = null;
        public EducationExperienceManager(ApplicationDbContext context) : base(context)
        {
        }
        public static EducationExperienceManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new EducationExperienceManager(context);
            }
            return Instance;
        }
    }
}
