using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Update
{
    public class UpdateGame
    {
        private GroupProjectEntities context;

        public UpdateGame()
        {
            context = new GroupProjectEntities();
        }

        public UpdateGame(GroupProjectEntities groupprojectEntities)
        {
            context = groupprojectEntities;
        }

        public void UpdateGameMethod(Game gameToUpdate)
        {
            if ((context.Games.SingleOrDefault(x => x.game_id == gameToUpdate.game_id)) != null)
            {
                Game gameInDB = context.Games.Where<Game>(x => x.game_id == gameToUpdate.game_id).First();
                gameInDB.name = gameToUpdate.name;
                gameInDB.payout = gameToUpdate.payout;
                context.SaveChanges();
            }
            else { }
        }

    }
}
