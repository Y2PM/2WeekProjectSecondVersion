using ASP.Models;
using DBLayer;
using DBLayer.Read;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        EditMemberModel editmodel = new EditMemberModel();
        Member memberBeingSent = new Member();

        //initialise service
        static EndpointAddress endpoint = new EndpointAddress("http://trnlon11675:8081/Service"); //Ada
        //static EndpointAddress endpoint = new EndpointAddress("http://trnlon11605:8081/Service"); //Cemal
        //static EndpointAddress endpoint = new EndpointAddress("http://trnlon11566:8081/Service"); //Joseph

        IServe proxy = ChannelFactory<IServe>.CreateChannel(new BasicHttpBinding(), endpoint);
        //might need intermediary method to mimic global userid
        static public int currentuser;
        string gamenameodds = "Odds N Evens";
        string gamenamelottery = "Lottery";
        string gamenamelucky = "Lucky Number";
        static public List<int> game;
        static public int oegame;
        static public int lngame;

        // GET: MemberSide
        public ActionResult LogIn()
        {
            return View(logmodel);
        }
        
        [HttpPost]
        public ActionResult LogIn(LogInModel logmodel)
        {
            if (proxy.LoginServiceMethod(logmodel.Username, logmodel.Password) == true)
                //logwork(logmodel.Username, logmodel.Password) == true)
            {
                currentuser = proxy.ReadCurrentMember(logmodel.Username, logmodel.Password);
                GamesModel gamemodel = new GamesModel();
                gamemodel.priceO = proxy.ReadGamePrice(gamenameodds);
                gamemodel.priceL = proxy.ReadGamePrice(gamenamelottery);
                gamemodel.priceLN = proxy.ReadGamePrice(gamenamelucky);
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

        [HttpPost]
        public ActionResult SignUp(SignUpModel signmodel)
        {
            if (proxy.ReadMemberNewUsername(signmodel.Username) == true) //if sign up is successfully completed
            {
                memberBeingSent.m_name = signmodel.Name;
                memberBeingSent.m_username = signmodel.Username;
                memberBeingSent.m_password = signmodel.Password;
                memberBeingSent.m_account = 0.0m;
                proxy.CreateMemberServiceMethod(memberBeingSent);
                return View("LogIn", logmodel);
            }
            else
            {
                signmodel.signerror = "Sign up could not be completed. Please try another username";
                return View("SignUp", signmodel);
            }
        }

        public ActionResult Games(GamesModel gamemodel)
        {
            if (currentuser != 0)
            {
                gamemodel.priceO = proxy.ReadGamePrice(gamenameodds);
                gamemodel.priceL = proxy.ReadGamePrice(gamenamelottery);
                gamemodel.priceLN = proxy.ReadGamePrice(gamenamelucky);
                return View(gamemodel);
            }
            else
            {
                LogInModel logmodel = new LogInModel();
                logmodel.accessmessage = "To access the Games page you must log in";
                return View("LogIn", logmodel);
            }
        }

        //remove return view for all the games (or make it just the games page and gamemodel)
        public ActionResult PlayOdds()
        {
            gamemodel.priceO = proxy.ReadGamePrice(gamenameodds);
            gamemodel.priceL = proxy.ReadGamePrice(gamenamelottery);
            gamemodel.priceLN = proxy.ReadGamePrice(gamenamelucky);
            decimal currentbalance = proxy.ReadMemberAccount(currentuser);
            if (proxy.UpdateMemberAccountPay(currentuser, currentbalance, gamemodel.priceO) == true)
            {
                
                //takes a game win method. if it returns true read game payout and add to current user account
                if (DecWin() == true)
                {
                    decimal payout = proxy.ReadGamePayout(gamenameodds);
                    //int memberid = getUserId(logmodel.Username, logmodel.Password);
                    proxy.UpdateMemberAccount(currentuser, currentbalance, payout);
                    //read game payout and add the current user's account
                    gamemodel.resultmessageO = "Congrats, you won! Keep your lucky streak going and play on!";
                }
                else
                {
                    gamemodel.resultmessageO = "Better luck next time. Play again to turn your luck around.";
                }
                gamemodel.announceO = "The winning number is: ";
                gamemodel.oddevennumber = oegame.ToString();
            }
            else
            {
                gamemodel.fundserrorO = "You have insufficient funds to play this game. Go to Edit Account.";
            }
            return View("Games", gamemodel);
        }

        [HttpPost]
        public ActionResult PlayLottery(GamesModel gamemodel)
        {
            gamemodel.priceO = proxy.ReadGamePrice(gamenameodds);
            gamemodel.priceL = proxy.ReadGamePrice(gamenamelottery);
            gamemodel.priceLN = proxy.ReadGamePrice(gamenamelucky);
            decimal currentbalance = proxy.ReadMemberAccount(currentuser);
            gamemodel.spaces = "   ";
            if (proxy.UpdateMemberAccountPay(currentuser, currentbalance, gamemodel.priceL) == true)
            {
                //takes a game win method. if it returns true read game payout and add to current user account
                if (userlottovalidate(gamemodel.one, gamemodel.two, gamemodel.three, gamemodel.four, gamemodel.five, gamemodel.six) == false)
                {
                    gamemodel.lotteryerror = "Ensure that Lottery numbers are unique";
                }
                else
                {
                        if (LottoWin(gamemodel.one, gamemodel.two, gamemodel.three, gamemodel.four, gamemodel.five, gamemodel.six) == true)
                        {
                            //read game payout and add the current user's account
                            decimal payout = proxy.ReadGamePayout(gamenamelottery);
                            proxy.UpdateMemberAccount(currentuser, currentbalance, payout);
                            gamemodel.resultmessageL = "Congrats, you won! Keep your lucky streak going and play on!";
                        }
                        else
                        {
                            gamemodel.resultmessageL = "Better luck next time. Play again to turn your luck around.";
                        }
                        gamemodel.announceL = "The winning numbers are: ";
                        gamemodel.lotterynumbers = game;
                }
                return View("Games", gamemodel);
            }
            else
            {
                gamemodel.fundserrorL = "You have insufficient funds to play this game. Go to Edit Account.";
            }
            
            return View("Games", gamemodel);
        }

        [HttpPost]
        public ActionResult PlayLucky(GamesModel gamemodel)
        {
            gamemodel.priceO = proxy.ReadGamePrice(gamenameodds);
            gamemodel.priceL = proxy.ReadGamePrice(gamenamelottery);
            gamemodel.priceLN = proxy.ReadGamePrice(gamenamelucky);
            decimal currentbalance = proxy.ReadMemberAccount(currentuser);
            if (proxy.UpdateMemberAccountPay(currentuser, currentbalance, gamemodel.priceLN) == true)
            {
                //takes a game win method. if it returns true read game payout and add to current user account
                if (LuckyNWin(gamemodel.usernumber) == true)
                {
                    //read game payout and add the current user's account

                    gamemodel.resultmessageLN = "Congrats, you won! Keep your lucky streak going and play on!";
                }
                else
                {
                    gamemodel.resultmessageLN = "Better luck next time. Play again to turn your luck around.";
                }
                gamemodel.announceLN = "The winning number is: ";
                gamemodel.luckynumber = oegame.ToString();
            }
            else
            {
                gamemodel.fundserrorLN = "You have insufficient funds to play this game. Go to Edit Account.";
            }
            return View("Games", gamemodel);
        }

        public ActionResult EditMember()
        {
            if (currentuser != 0)
            {
            return View("EditMember", editmodel);
            }
            else
            {
                LogInModel logmodel = new LogInModel();
                logmodel.accessmessage = "To access the Edit Account page you must log in";
                return View("LogIn", logmodel);
            }
        }

        //[HttpPost]
        //public ActionResult EditMemberPassword(EditMemberModel editmodel)
        //{
        //    ////add your update member method using currentuser and editmodel.newpassword
        //    //if (editmodel.newpassword != editmodel.confirmpassword)
        //    //{
        //    //    //update member password with editmodel.confirmpassword value
        //    //    editmodel.passwordsuccess = "Your password has been changed successfully";
        //    //}
        //    //else
        //    //{
        //    //    editmodel.passworderror = "Please ensure you have typed in the correct password";
        //    //}
        //    ////if (editmodel.addtobalance == null && editmodel.newpassword != null && editmodel.currentpassword != null)
        //    //if (editmodel.newpassword != editmodel.confirmpassword || proxy.ReadMemberPassword == false)
        //    //{
        //    //    editmodel.passworderror = "Please ensure you have typed in the correct password";// and that your new and confiremed passwords match";
        //    //}

        //    //memberBeingSent.member_id = currentuser;
        //    //memberBeingSent.m_password = editmodel.newpassword;
        //    //proxy.UpdateMemberServiceMethod(memberBeingSent);
            
        //    return View("EditMember", editmodel);
        //}

        [HttpPost]
        public ActionResult EditMemberPassword(EditMemberModel editmodel)
        {

            if (editmodel.newpassword != editmodel.confirmpassword || proxy.UpdateMemberPassword(currentuser, editmodel.currentpassword, editmodel.confirmpassword) == false)
            {
                editmodel.passworderror = "Please ensure you have typed in the correct password";
            }
            else
            {
                editmodel.passwordsuccess = "Your password has been changed successfully";
            }
            return View("EditMember", editmodel);
        }

        [HttpPost]
        public ActionResult EditMemberBalance(EditMemberModel editmodel)
        {
            
            decimal currentbalance = proxy.ReadMemberAccount(currentuser);
            proxy.UpdateMemberAccount(currentuser, currentbalance, editmodel.addtobalance);
            editmodel.balancesuccess = "£" + editmodel.addtobalance + " was added to your account";
            return View("EditMember", editmodel);
        }

        public ActionResult LogOut()
        {
            currentuser = 0;
            return View("SignUp", signmodel);
        }

            List<int> lotterylist;
            List<int> userlotterylist;
            int result;
            int matchcount;

            public int GetOneTen()
            {
                Random rand = new Random();
                oegame = rand.Next(1, 10);
                //generates a random number between 1 and 10
                return oegame;
            }

            public bool DecWin()
            {
                if (GetOneTen() % 2 == 0)
                {
                    //if the result is even
                    //add from the context the game payout value to the user account value
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public List<int> Lottery()
            {
                Random rand = new Random();

                List<int> unsortedlotterylist = new List<int>();

                while (unsortedlotterylist.Count < 6)
                {
                    result = rand.Next(1, 51);
                    if (unsortedlotterylist.Contains(result))
                    {
                        result++;
                    }
                    unsortedlotterylist.Add(result);
                }
                // this makes sure the list contains 6 unique, random numbers between 1 and 50
                lotterylist = unsortedlotterylist.OrderBy(v => v).ToList();
                //this sorts the list in ascending order
                return lotterylist;

            }

            public bool userlottovalidate(int one, int two, int three, int four, int five, int six)
            {
                //returns true if the user's 6 given numbers are between 1 and 50
                List<int> numbers = new List<int>();
                List<int> unsorteduserlotterylist = new List<int>();
                numbers.Add(one);
                numbers.Add(two);
                numbers.Add(three);
                numbers.Add(four);
                numbers.Add(five);
                numbers.Add(six);

                foreach (var numb in numbers)
                {
                    if (!unsorteduserlotterylist.Contains(numb) && numb >= 1 && numb <= 50)
                    {
                        unsorteduserlotterylist.Add(numb);
                    }
                }
                if (unsorteduserlotterylist.Count == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public List<int> Userlottery(int one, int two, int three, int four, int five, int six)
            {
                List<int> unsorteduserlotterylist = new List<int>();
                if (userlottovalidate(one, two, three, four, five, six) == true)
                {
                    //if the user's numbers pass validation (6 distinct numbers between 1 and 50)
                    unsorteduserlotterylist.Add(one);
                    unsorteduserlotterylist.Add(two);
                    unsorteduserlotterylist.Add(three);
                    unsorteduserlotterylist.Add(four);
                    unsorteduserlotterylist.Add(five);
                    unsorteduserlotterylist.Add(six);
                    //the user's six numbers are added to a list
                }

                userlotterylist = unsorteduserlotterylist.OrderBy(v => v).ToList();
                //the list is sorted so it can be compared

                ////Check if lotto numbers selected are unique


                return userlotterylist;
            }

            public int Matcher(List<int> game, List<int> user)
            {
                //counts how many of the user's numbers occur in the lottery numbers
                foreach (var n in user)
                {
                    if (game.Contains(n))
                    {
                        matchcount++;
                    }
                }
                return matchcount;
            }

            public bool Lotteryresult(List<int> game, List<int> user)
            {
                if (game == user)
                {
                    //if the generated numbers are the same as the users return true
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool LottoWin(int o, int t, int th, int f, int fi, int s)
            {
                game = Lottery(); //----------------> this is the list of the lottery 
                List<int> user = Userlottery(o, t, th, f, fi, s);
                int matches = Matcher(game, user);
                if (Lotteryresult(game, user) == true)
                {
                    decimal payout = proxy.ReadGamePayout(gamenamelucky);
                    decimal currentbalance = proxy.ReadMemberAccount(currentuser);
                    proxy.UpdateMemberAccount(currentuser, currentbalance, payout);
                    //when the generated numbers and the user numbers match
                    //add from the context the game payout value to the user account value
                    return true;
                }
                else if (matches == 4)
                {
                    //if the user has 4 of the winning numbers the can get a quarter of the payout
                    //decimal winamount = decimal payout value / 4
                    //update member account to add winamount
                    decimal payout = proxy.ReadGamePayout(gamenamelucky) / 4;
                    decimal currentbalance = proxy.ReadMemberAccount(currentuser);
                    proxy.UpdateMemberAccount(currentuser, currentbalance, payout);
                    return true;
                }
                else if (matches == 5)
                {
                    //the user gets a third of the payout
                    //decimal winamount = decimal payout value / 3
                    //update member account to add winamount
                    //no other lotto conditions warrant a payout
                    decimal payout = proxy.ReadGamePayout(gamenamelucky) / 3;
                    decimal currentbalance = proxy.ReadMemberAccount(currentuser);
                    proxy.UpdateMemberAccount(currentuser, currentbalance, payout);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public List<int> LuckyNumber()
            {
                //generates a number between 1 and 10. makes it occur 3 times in a list and all other values are distinct

                int lngame = GetOneTen();
                List<int> numberlist = new List<int>();
                numberlist.Add(lngame);
                numberlist.Add(lngame);
                numberlist.Add(lngame);

                while (numberlist.Count < 9)
                {
                    result = GetOneTen();
                    if (!numberlist.Contains(result))
                    {
                        numberlist.Add(result);
                    }
                }
                return numberlist;
            }

            public bool LuckyNWin(int user)
            {
                //if the user's number is the lucky number occuring 3 times in the list, they win
                List<int> lnumbers = LuckyNumber();
                int numcount = lnumbers.Where(x => x.Equals(user)).Count();
                if (numcount >= 3)
                {
                    //add payout value to the user's account
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool logwork(string use, string pas)
            {
                if (proxy.LoginServiceMethod(use, pas) == true)
                {
                    currentuser = proxy.ReadCurrentMember(use, pas);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
