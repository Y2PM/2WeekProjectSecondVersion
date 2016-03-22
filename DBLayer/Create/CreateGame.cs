using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Create
{
    public class CreateGame
    {
        private GroupProjectEntities context;

        public CreateGame()
        {
            context = new GroupProjectEntities();
        }

        public CreateGame(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public void CreateGameMethod(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }
    }
}
