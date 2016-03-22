using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Read
{
    public class ReadMember
    {
        private GroupProjectEntities context;

        public ReadMember()
        {
            context = new GroupProjectEntities();
        }

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
    }
}
