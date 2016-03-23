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
        LogInModel logmodel = new LogInModel();
        GamesModel gamemodel = new GamesModel();
        SignUpModel signmodel = new SignUpModel();

        // GET: MemberSide
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            //call method that reads the input from logmodel.Username and logmodel.Password

            return View(logmodel);
        }
        
        [HttpPost]
        public ActionResult LogIn(LogInModel logmodel)
        {
            //user = logmodel.Username;
            //pass = logmodel.Password;

            if (logmodel.logwork(logmodel.Username, logmodel.Password) == true)
            {
                return View("Games", gamemodel);
            }
            else
            {
                return View(logmodel);
            } 
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