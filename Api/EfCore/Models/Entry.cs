using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.EfCore.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        public string EntryContent { get; set; }
        public string EntryName { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
