using System;
using System.Linq;

namespace DBLayer.Update
{
    public class UpdateMember : IDisposable
    {
        private GroupProjectEntities context;

        public UpdateMember()
        {
            context = new GroupProjectEntities();
        }

        public UpdateMember(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public void UpdateMemberMethod(Member memberToUpdate)
        {
            if ((context.Members.SingleOrDefault(x => x.member_id == memberToUpdate.member_id)) != null)
            {
                Member memberInDB = context.Members.Where<Member>(x => x.member_id == memberToUpdate.member_id).First();
                memberInDB.m_name = memberToUpdate.m_name;
                memberInDB.m_password = memberToUpdate.m_password;
                context.SaveChanges();
            }
            else { }
        }

        public void UpdateMemberAccount(int memberid, decimal currentbalance, decimal payout)
        {
            using (var context = new GroupProjectEntities()) 
            { 
                var member = context.Members.Find(memberid);
                if (member.m_account == null || member.m_account == 0)
                {
                    member.m_account = currentbalance + payout;
                }
                else
                {
                    member.m_account = currentbalance + payout;
                }
                context.SaveChanges();
            }
        }

        public bool UpdateMemberAccountPay(int memberid, decimal currentbalance, decimal price)
        {
            using (var context = new GroupProjectEntities())
            {
                var member = context.Members.Find(memberid);
                if (member.m_account >= price)
                    //(member.m_account == null || member.m_account == 0)
                {
                    member.m_account = currentbalance - price;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void UpdateMemberAccountBalance(int memberid, decimal currentbalance, decimal addtoaccount)
        {
            using (var context = new GroupProjectEntities())
            {
                var member = context.Members.Find(memberid);
                if (member.m_account == null || member.m_account == 0)
                {
                    member.m_account = currentbalance + addtoaccount;
                }
                else
                {
                    member.m_account = currentbalance + addtoaccount;
                }
                context.SaveChanges();
            }
        }

        public bool UpdateMemberPassword(int memberid, string oldpassword, string newpassword)
        {
            using (var context = new GroupProjectEntities())
            {
                string actualpassword = null;
                var memberpasswordquery = (from e in context.Members
                                           where e.member_id == memberid
                                           select e.m_password);

                foreach (var p in memberpasswordquery)
                {
                    actualpassword = p.ToString();
                }
                if (actualpassword == oldpassword)
                {
                    var member = context.Members.Find(memberid);
                    member.m_password = newpassword;
                    context.SaveChanges();
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
