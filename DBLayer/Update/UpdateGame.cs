﻿using System;
using System.Linq;

namespace DBLayer.Update
{
    public class UpdateGame : IDisposable
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
                gameInDB.price = gameToUpdate.price;
                context.SaveChanges();
            }
            else { }
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
