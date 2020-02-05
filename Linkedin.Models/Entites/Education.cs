using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Education")]
    public class Education
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("School")]
        public Guid SchoolId { get; set; }
        public virtual SavedPlace School { get; set; }
        public string Grade { get; set; }
        public Degree Degree { get; set; }
        public string Description { get; set; }
        public string Acticites { get; set; }

        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }
    }
}
