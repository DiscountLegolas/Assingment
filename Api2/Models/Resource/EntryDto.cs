using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Models.Resource
{
    public class EntryDto
    {
        public string EntryContent { get; set; }
        public string EntryName { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
    }
}
