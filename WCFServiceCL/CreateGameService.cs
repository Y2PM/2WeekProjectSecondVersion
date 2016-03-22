using DBLayer.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceCL
{
    public class CreateGameService : ICreateGameService
    {
        CreateGame CreateGameObject = new CreateGame();
        CreateGameServiceClass CreateGameServiceClassObject = new CreateGameServiceClass();

        public void CreateGameServiceMethod(DBLayer.Game game)
        {
            CreateGameObject.CreateGameMethod(game);
        }
    }
}
