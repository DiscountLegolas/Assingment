using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.Resources
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public UserDto User { get; set; }
        public EntryDto Entry { get; set; }
    }
}
