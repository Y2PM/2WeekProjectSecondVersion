using ASP.Models;
using DBLayer;
using DBLayer.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFServiceCL;

namespace ASP.Controllers
{
    public class MemberSideController : Controller
    {
        LogInModel logmodel = new LogInModel();
        GamesModel gamemodel = new GamesModel();
        SignUpModel signmodel = new SignUpModel();

        //initialise service
        static EndpointAddress endpoint = new EndpointAddress("http://trnlon11675:8081/Service");
        IServe proxy = ChannelFactory<IServe>.CreateChannel(new BasicHttpBinding(), endpoint);
        //might need intermediary method to mimic global userid
        //int currentuser = ;

        public bool logwork(string use, string pas)
        {
            if (proxy.LoginServiceMethod(use, pas) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: MemberSide
        public ActionResult LogIn()
        {
            return View(logmodel);
        }
        
        [HttpPost]
        public ActionResult LogIn(LogInModel logmodel)
        {

            if (logwork(logmodel.Username, logmodel.Password) == true)
            {
                return View("Games", gamemodel);
            }
            else
            {
                logmodel.logerror = "Log in could not be completed. Please Ensure you have entered the correct username and password";
                return View(logmodel);
            } 
        }

        public ActionResult SignUp()
        {
            return View(signmodel);
        }

    //    public ActionResult SignUp(SignUpModel signmodel)
    //    {
    //        if () //if sign up is successfully completed
    //        {
    //        return View("LogIn", logmodel);
    //        }
    //        else
    //{
        //signmodel.signerror = "Sign up could not be completed. Please try another name or username";
    //            return View(signmodel);
    //}
    //    }

        public ActionResult Games()
        {
                return View();
        }

        ////remove return view for all the games (or make it just the games page and gamemodel)
        //public ActionResult PlayOdds()
        //{
        //    //takes a game win method. if it returns true read game payout and add to current user account
        //    if (decwin == true)
        //    {
        //        //read game payout and add the current user's account
        //        //gamemodel.resultmessageO = "Congrats, you won! Keep your lucky streak going and play on!"
        //    }
        //    else
        //    {
        //        gamemodel.resultmessageO = "Better luck next time. Play again to turn your luck around."
        //    }
        //    return View("Games", gamemodel);
        //}

        //public ActionResult PlayLottery()
        //{
        //    //takes a game win method. if it returns true read game payout and add to current user account
        //    if (lottowin == true)
        //    {
        //        //read game payout and add the current user's account
        //        //gamemodel.resultmessageO = "Congrats, you won! Keep your lucky streak going and play on!"
        //    }
        //    else
        //    {
        //        gamemodel.resultmessageO = "Better luck next time. Play again to turn your luck around."
        //    }
        //    return View("Games", gamemodel);
        //}

        //public ActionResult PlayLucky()
        //{
        //    //takes a game win method. if it returns true read game payout and add to current user account
        //    if (luckynwin == true)
        //    {
        //        //read game payout and add the current user's account
        //        //gamemodel.resultmessageO = "Congrats, you won! Keep your lucky streak going and play on!"
        //    }
        //    else
        //    {
        //        gamemodel.resultmessageO = "Better luck next time. Play again to turn your luck around."
        //    }
        //    return View("Games", gamemodel);
        //}
    }
}