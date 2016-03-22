using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Create
{
    public class CreateMember
    {
        private GroupProjectEntities context;

        public CreateMember()
        {
            context = new GroupProjectEntities();
        }

        public CreateMember(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public void CreateMemberMethod(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }
    }
}
