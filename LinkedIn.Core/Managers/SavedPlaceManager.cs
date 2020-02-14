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
    public class SavedPlaceManager : Repository<SavedPlace, ApplicationDbContext>
    {
        private static SavedPlaceManager Instance = null;
        public SavedPlaceManager(ApplicationDbContext context) : base(context)
        {

        }
        public static SavedPlaceManager GetInstance(ApplicationDbContext context)
        {
            if(Instance == null)
            {
                Instance = new SavedPlaceManager(context);
            }
            return Instance;
        }
    }
}
