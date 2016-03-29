using System;
using System.Linq;

namespace DBLayer.Delete
{
    public class DeleteGame : IDisposable
    {
        private GroupProjectEntities context;


        public DeleteGame(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public virtual void DeleteGameMethod(int game_id)
        {
            Game _game = context.Games.Single(x => x.game_id == game_id);
            if (game_id != 0)
            {
                context.Games.Remove(_game);
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
