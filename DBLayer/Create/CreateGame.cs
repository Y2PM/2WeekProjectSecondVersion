using System;

namespace DBLayer.Create
{
    public class CreateGame : IDisposable
    {
        private GroupProjectEntities context;


        public CreateGame(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public void CreateGameMethod(Game game)
        {
            context.Games.Add(game);
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