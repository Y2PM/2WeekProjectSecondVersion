using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class EditMemberModel
    {
        public string currentpassword { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }
        public decimal addtobalance { get; set; }
        public string passworderror { get; set; }
        public string passwordsuccess { get; set; }
        public string balancesuccess { get; set; }
    }
}