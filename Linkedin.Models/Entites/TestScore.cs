using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("TestScore")]
    class TestScore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public WorkExperience Associated { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}
