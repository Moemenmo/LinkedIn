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
    public class TestScoreManager : Repository<TestScore, ApplicationDbContext>
    {
        private static TestScoreManager Instance = null;
        public TestScoreManager(ApplicationDbContext context) : base(context)
        {
        }
        public static TestScoreManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new TestScoreManager(context);
            }
            return Instance;
        }
    }
}
