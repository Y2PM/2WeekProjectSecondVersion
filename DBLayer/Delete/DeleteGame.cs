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

        public virtual void DeleteGameMethod(string game)
        {
            Game _game = context.Games.Single(x => x.name == game);
            if (game != null)
            {
                context.Games.Remove(_game);
                context.SaveChanges();
            }
        }
    }
}
