using System;
using DBLayer;
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

        //"Log in could not be completed. Please Ensure you have entered the correct username and password"

        BetterWork bw = new BetterWork();

        public bool logwork(string use, string pas)
        {
           if (bw.login(use, pas) == true)
           {
               return true;
           }
           else
           {
               return false;
           }
        }
        
    }
}