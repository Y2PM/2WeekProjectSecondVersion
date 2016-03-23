using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectFDM
{
    public class BetterWork
    {
        int memid = 0;

        public bool login(string user, string pass)
        {
            using (var context = new GroupProjectEntities())
            {
                //var deptforremove = context.Members.Where(m => m.usernamename == user);

                var memberidquery = (from e in context.Members
                                     where e.m_username == user
                                     select e.member_id);
                foreach (var mem in memberidquery)
                {
                    memid = Convert.ToInt32(mem);
                }

                var m = context.Members.Find(memid);
                if (m.m_password == pass)
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
}

