using Site.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class EntryPageModel
    {
        public EntryDto Entry { get; set; }
        public List<CommentDto> Comments { get; set; }
        public string Comment { get; set; }
    }
}
