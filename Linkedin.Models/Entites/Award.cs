using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Award")]
   public class Award
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("WorkExperience")]

        public WorkExperience Associated { get; set; }
        public string    Issuer { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}
