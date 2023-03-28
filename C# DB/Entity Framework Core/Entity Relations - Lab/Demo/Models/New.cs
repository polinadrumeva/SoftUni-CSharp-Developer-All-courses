using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class New
    {
        public New()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CommentId { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
