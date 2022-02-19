using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Models.Resource
{
    public class CommentDto
    {
        public string CommentContent { get; set; }
        public string CommentMakerName { get; set; }
        public string EntryName { get; set; }
    }
}
