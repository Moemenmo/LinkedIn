using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Linkedin.Models.Entites
{
    [Table("Skill")]
    public class Skill
    {
        public Skill()
        {
            Id = Guid.NewGuid();
            Users = new HashSet<ApplicationUser>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> Users{ get; set; }
    }
}