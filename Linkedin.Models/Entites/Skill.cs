using System;
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
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}