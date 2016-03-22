using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class MemberSideController : Controller
    {
        // GET: MemberSide
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Games()
        {
            return View();
        }

        public ActionResult PlayOdds()
        {
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