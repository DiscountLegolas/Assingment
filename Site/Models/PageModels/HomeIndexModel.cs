using Site.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class HomeIndexModel
    {
        public List<EntryDto> Entries { get; set; }
    }
}
