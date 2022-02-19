using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.EfCore.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string PassWord { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
