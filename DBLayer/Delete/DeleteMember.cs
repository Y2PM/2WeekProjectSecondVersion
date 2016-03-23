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

        public virtual void DeleteMemberMethod(int member_id)
        {
            Member _member = context.Members.Single(x => x.member_id == member_id);
            if (member_id != null)
            {
                context.Members.Remove(_member);
                context.SaveChanges();
            }
        }

    }
}
