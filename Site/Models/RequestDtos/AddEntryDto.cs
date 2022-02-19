using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.RequestDtos
{
    public class AddEntryDto
    {
        public string EntryContent { get; set; }
        public string EntryName { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
