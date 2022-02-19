using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.EfCore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Entry> EntriesOnCategory { get; set; }
    }
}
