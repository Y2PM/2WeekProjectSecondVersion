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
