using DBLayer;
using DBLayer.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceCL.Create
{
    public class CreateGameService : IServe
    {
        CreateGame CreateGameObject = new CreateGame();

        public void CreateGameServiceMethod(Game game)
        {
            CreateGameObject.CreateGameMethod(game);
        }


        public void CreateMemberServiceMethod(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
