using DBLayer;
using DBLayer.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceCL.Create
{
    public class ServiceMethodClass : IServe//CreateGameService
    {
        

        public void CreateGameServiceMethod(Game game)
        {
            CreateGame CreateGameObject = new CreateGame();
            CreateGameObject.CreateGameMethod(game);
        }


        public void CreateMemberServiceMethod(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
