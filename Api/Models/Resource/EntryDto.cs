using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Resource
{
    public class EntryDto
    {
        public int EntryId { get; set; }
        public string EntryContent { get; set; }
        public string EntryName { get; set; }
        public string CategoryName { get; set; }
    }
}
