using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Post")]
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<ApplicationUser>();
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<ApplicationUser> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
