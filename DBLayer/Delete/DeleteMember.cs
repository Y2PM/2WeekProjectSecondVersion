using System;
using System.Linq;

namespace DBLayer.Delete
{
    public class DeleteMember : IDisposable
    {
        private GroupProjectEntities context;

       

        public DeleteMember(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public virtual void DeleteMemberMethod(int member_id)
        {
            Member _member = context.Members.Single(x => x.member_id == member_id);
            if (member_id != 0)
            {
                context.Members.Remove(_member);
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
