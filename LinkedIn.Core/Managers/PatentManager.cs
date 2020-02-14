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
    public class PatentManager : Repository<Patent, ApplicationDbContext>
    {
        private static PatentManager Instance = null;
        public PatentManager(ApplicationDbContext context) : base(context)
        {
        }
        public static PatentManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new PatentManager(context);
            }
            return Instance;
        }
    }
}
