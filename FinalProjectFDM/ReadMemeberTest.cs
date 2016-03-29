using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectFDM
{
    public class ReadMemeberTest
    {
        public bool login(string user, string pass)
        {
            //int memid = 0;
            using (var context = new GroupProjectEntities())
            {
                var memberidquery = (from e in context.Members
                                     where e.m_username == user
                                     select e.member_id);
                var memid = memberidquery;

                var m = context.Members.Find(memid);
                //if (memid == 0)
                //{
                //    return false;
                //}
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
