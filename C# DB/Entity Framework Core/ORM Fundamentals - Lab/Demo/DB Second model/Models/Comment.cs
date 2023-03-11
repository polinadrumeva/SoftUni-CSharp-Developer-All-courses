using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstmodel.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int NewId { get; set; }

        public virtual News New { get; set; }

        public string Author { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
