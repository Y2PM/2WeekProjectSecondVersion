using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFServiceCL;

namespace ASP.Controllers
{
    public class GamesController : Controller
    {
        LogInModel logmodel = new LogInModel();
        GamesModel gamemodel = new GamesModel();
        SignUpModel signmodel = new SignUpModel();
        EditMemberModel editmodel = new EditMemberModel();
        //Member memberBeingSent = new Member();

        //initialise service
        //static EndpointAddress endpoint = new EndpointAddress("http://trnlon11675:8081/Service"); //Ada
        static EndpointAddress endpoint = new EndpointAddress("http://trnlon11605:8081/Service"); //Cemal
        //static EndpointAddress endpoint = new EndpointAddress("http://trnlon11566:8081/Service"); //Joseph

        IServe proxy = ChannelFactory<IServe>.CreateChannel(new BasicHttpBinding(), endpoint);
        //might need intermediary method to mimic global userid
        static int currentuser = MemberSideController.currentuser;
        string gamenameodds = "Odds N Evens";
        string gamenamelottery = "Lottery";
        string gamenamelucky = "Lucky Number";
        static public List<int> game;

        // GET: Games
        public ActionResult GamesPage(GamesModel gamemodel)
        {
            if (currentuser != 0)
            {
                gamemodel.priceO = proxy.ReadGamePrice(gamenameodds);
                gamemodel.priceL = proxy.ReadGamePrice(gamenamelottery);
                gamemodel.priceLN = proxy.ReadGamePrice(gamenamelucky);
                //return View()
                return View(gamemodel);
            }
            else
            {
                LogInModel logmodel = new LogInModel();
                logmodel.accessmessage = "To access the Games page you must log in";
                return View("LogIn", logmodel);
            }
        }
    }
}