using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class LogInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string logerror { get; set; }
        public string accessmessage { get; set; }
    }
}