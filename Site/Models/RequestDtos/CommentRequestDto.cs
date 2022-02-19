using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.RequestDtos
{
    public class CommentRequestDto
    {
        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }
    }
}
