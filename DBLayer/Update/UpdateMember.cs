using DBLayer.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Update
{
    public class UpdateMember
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
    }
}
