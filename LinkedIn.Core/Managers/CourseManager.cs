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
    public class CourseManager : Repository<Course, ApplicationDbContext>
    {
        private static CourseManager Instance = null;
        public CourseManager(ApplicationDbContext context) : base(context)
        {
        }
        public static CourseManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new CourseManager(context);
            }
            return Instance;
        }
    }
}
