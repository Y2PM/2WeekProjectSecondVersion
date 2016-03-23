using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Delete
{
    public class DeleteGame
    {
        private GroupProjectEntities context;

        public DeleteGame()
        {
            context = new GroupProjectEntities();
        }

        public DeleteGame(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public virtual void DeleteGameMethod(int game_id)
        {
            Game _game = context.Games.Single(x => x.game_id == game_id);
            if (game_id != null)//This is pointless because it's always true from joe.
            {
                context.Games.Remove(_game);
                context.SaveChanges();
            }
        }
    }
}
