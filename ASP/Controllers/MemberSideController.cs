using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class MemberSideController : Controller
    {
        public static LogInModel logmodel; // = new LogInModel();

        // GET: MemberSide
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            //call method that reads the input from logmodel.Username and logmodel.Password
            
            return View();
        }

        public ActionResult Games()
        {
            return View();
        }

        public ActionResult PlayOdds()
        {
            //
            return View();
        }

        public ActionResult PlayLottery()
        {
            return View();
        }

        public ActionResult PlayLucky()
        {
            return View();
        }
    }
}