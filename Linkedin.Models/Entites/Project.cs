using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Project")]
    class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPresent { get; set; }
        //list of users
        [ForeignKey("WorkExperience")]
        public WorkExperience Associated { get; set; }
        [DataType(DataType.Url)]
        public string URL { get; set; }
        public string Description { get; set; }
    }
}
