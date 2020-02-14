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
    public class PostManager : Repository<Post, ApplicationDbContext>
    {
        private static PostManager Instance = null;
        public PostManager(ApplicationDbContext context) : base(context)
        {
        }
        public static PostManager GetInstance(ApplicationDbContext context)
        {
            if (Instance == null)
            {
                Instance = new PostManager(context);
            }
            return Instance;
        }
    }
}
