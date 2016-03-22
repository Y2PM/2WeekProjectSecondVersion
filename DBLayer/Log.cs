//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DBLayer
//{
//    public class Log
//    {
//        public bool login(string username, string pass)
//        {
//            using (var context = new GroupProjectEntities())
//            {

//                var mem = context.Members.Find(username);
//                if (mem.m_password == pass)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }

//            }
//        }
//    }
//}


//Log logrepo = new Log();
//if (logrepo.login(logmodel.Username, logmodel.Password) == true)
//{
//@Html.ActionLink("", "Games", "MemberSide")
//}