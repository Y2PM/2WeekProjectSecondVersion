using System;

namespace DBLayer.Create
{
    public class CreateMember : IDisposable
    {
        private GroupProjectEntities context;


        public CreateMember(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public void CreateMemberMethod(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
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
