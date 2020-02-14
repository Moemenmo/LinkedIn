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
    public class AwardManager : Repository<Award, ApplicationDbContext>
    {
        private static AwardManager Instance = null;
        public AwardManager(ApplicationDbContext context) : base(context)
        {

        }
        public static AwardManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new AwardManager(context);
            }
            return Instance;
        }
    }
}
