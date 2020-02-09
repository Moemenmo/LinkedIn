using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Comment")]
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid();
            Likes = new HashSet<ApplicationUser>();
            Replies = new HashSet<Comment>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string PicURL { get; set; }
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<Comment> Replies { get; set; }
        public ICollection<ApplicationUser> Likes { get; set; }
    }
}
