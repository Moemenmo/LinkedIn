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
    public class WorkExperienceManager : Repository<WorkExperience, ApplicationDbContext>
    {
        private static WorkExperienceManager Instance;
        public WorkExperienceManager(ApplicationDbContext context) : base(context)
        {

        }
        public static WorkExperienceManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new WorkExperienceManager(context);
            }
            return Instance;
        }
    }
}
