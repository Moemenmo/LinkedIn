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
    public class ProjectManager : Repository<Project, ApplicationDbContext>
    {
        private static ProjectManager Instance = null;
        public ProjectManager(ApplicationDbContext context) : base(context)
        {
        }
        public static ProjectManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new ProjectManager(context);
            }
            return Instance;
        }
    }
}
