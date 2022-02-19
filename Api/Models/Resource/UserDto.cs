using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Resource
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string PassWord { get; set; }
    }
}
