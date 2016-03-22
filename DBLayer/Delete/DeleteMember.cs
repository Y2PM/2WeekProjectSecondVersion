using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Delete
{
    public class DeleteMember
    {
        private GroupProjectEntities context;

        public DeleteMember()
        {
            context = new GroupProjectEntities();
        }

        public DeleteMember(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public virtual void DeleteMemberMethod(int id)
        {
            Member member = context.Members.Single(x => x.member_id == id);
            if (member != null)
            {
                context.Members.Remove(member);
                context.SaveChanges();
            }
        }
    }
}
