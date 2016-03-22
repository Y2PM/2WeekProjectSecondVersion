using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class SignUpModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string signerror { get; set; }

        //"Sign up could not be completed. Please try another name or username."
    }
}