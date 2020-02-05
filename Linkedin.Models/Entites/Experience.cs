using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Experience")]

    class Experience
    {
        public ExperienceType Type { get; set; }
        public Guid Id { get; set; }

    }
}
