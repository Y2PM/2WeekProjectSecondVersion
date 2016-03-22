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
                memberInDB.m_username = memberToUpdate.m_username;
                memberInDB.m_password = memberToUpdate.m_password;
                memberInDB.m_account = memberToUpdate.m_account;
                context.SaveChanges();
            }
            else { }
        }
    }
}
