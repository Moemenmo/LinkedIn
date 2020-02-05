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
            Likes = new HashSet<ApplicationUser>();
            Replies = new HashSet<Comment>(); 
        }
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public string PicURL { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<Comment> Replies { get; set; }
        public ICollection<ApplicationUser> Likes { get; set; }
    }
}
