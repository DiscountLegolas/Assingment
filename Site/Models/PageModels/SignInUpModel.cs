using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class SignInUpModel
    {
        public string SignInUserName { get; set; }
        public string SignInPassword { get; set; }

        public string SignUpUserName { get; set; }
        public string SignUpEMail { get; set; }
        public string SignUpPassword { get; set; }
    }
}
