using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.PageModels
{
    public class AddEntryPageModel
    {
        public string EName { get; set; }
        public string EContent { get; set; }
        public int CategoryId { get; set; }
    }
}
