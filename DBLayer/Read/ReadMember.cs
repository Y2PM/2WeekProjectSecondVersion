using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace DBLayer.Read
{
    public class ReadMember : IDisposable
    {
        private GroupProjectEntities context;
        private readonly ILog logger = LogManager.GetLogger("ReadMember.cs");

        public ReadMember(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public List<Member> ReadAllMembers()
        {
            List<Member> _members = context.Members.ToList<Member>();
            return _members;
        }

        public Member ReadSpecificMember(int id)
        {
            Member noMemberFound = new Member()
            {
                m_name = "Member Does Not Exist"
            };

            if ((context.Members.SingleOrDefault(x => x.member_id == id)) != null)
            {
                Member _member = context.Members.Where<Member>(x => x.member_id == id).First();
                return _member;
            }
            else { return noMemberFound; }
        }

        public List<Log> ReadAllLogs()
        {
            List<Log> _logs = context.Logs.ToList<Log>();
            return _logs;
        }

        public bool login(string user, string pass)
        {
            int memid = 0;

            var memberidquery = (from e in context.Members
                                 where e.m_username == user
                                 select e.member_id);

            foreach (var mem in memberidquery)
            {
                memid = Convert.ToInt32(mem);
            }

            var m = context.Members.Find(memid);
            string messageF = "Login fail, Username: " + user;

            if (memid == 0)
            {
                logger.Info(messageF);
                return false;
            }
            if (m.m_password == pass)
            {
                logger.Info("Login sucsess, Username: " + m.m_username);
                return true;
            }
            else
            {
                logger.Info(messageF);
                return false;
            }
        }

        public decimal ReadMemberAccount(int memberid)
        {
            using (var context = new GroupProjectEntities())
            {
                decimal memberaccount = 0.0m;

                var memberaccountquery = (from e in context.Members
                                          where e.member_id == memberid
                                          select e.m_account);
                foreach (var m_acc in memberaccountquery)
                {
                    memberaccount = Convert.ToDecimal(m_acc);
                }

                if (memberaccount == 0)
                {
                    return 0.0m;
                }
                else
                {
                    return memberaccount;
                }
            }
        }

        public int ReadCurrentMember(string user, string pass)
        {
            int memid = 0;
            using (var context = new GroupProjectEntities())
            {

                var memberidquery = (from e in context.Members
                                     where e.m_username == user
                                     select e.member_id);
                foreach (var mem in memberidquery)
                {
                    memid = Convert.ToInt32(mem);
                }

                return memid;
            }
        }

        public bool ReadMemberNewUsername(string username)
        {
            using (var context = new GroupProjectEntities())
            {
                List<int> memberlist = new List<int>();
                var uniqueusername = (from e in context.Members
                                      where e.m_username == username
                                      select e.member_id);
                foreach (var member in uniqueusername)
                {
                    memberlist.Add(member);
                }

                if (memberlist.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                context.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
