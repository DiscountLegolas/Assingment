using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.EfCore.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }
        public virtual User User { get; set; }
        public virtual Entry Entry { get; set; }
    }
}
