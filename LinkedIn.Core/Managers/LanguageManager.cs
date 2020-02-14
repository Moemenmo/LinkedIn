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
    public class LanguageManager : Repository<Language, ApplicationDbContext>
    {
        private static LanguageManager Instance = null;
        public LanguageManager(ApplicationDbContext context) : base(context)
        {
        }
        public static LanguageManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new LanguageManager(context);
            }
            return Instance;
        }
    }
}
