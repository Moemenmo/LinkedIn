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
    public class VolunteerExperienceManager : Repository<VolunteerExperience, ApplicationDbContext>
    {
        private static VolunteerExperienceManager Instance = null;
        public VolunteerExperienceManager(ApplicationDbContext context) : base(context)
        {
        }
        public static VolunteerExperienceManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new VolunteerExperienceManager(context);
            }
            return Instance;
        }
    }
}
