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
    public class SkillManager : Repository<Skill, ApplicationDbContext>
    {
        private static SkillManager Instance = null;
        public SkillManager(ApplicationDbContext context) : base(context)
        {
        }
        public static SkillManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new SkillManager(context);
            }
            return Instance;
        }
    }
}
