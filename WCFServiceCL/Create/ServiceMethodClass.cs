using DBLayer;
using DBLayer.Create;
using DBLayer.Delete;
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
            CreateMember CreateMemberObject = new CreateMember();
            CreateMemberObject.CreateMemberMethod(member);
        }


        public void DeleteGameServiceMethod(int game_id)
        {
            DeleteGame DeleteGameObject = new DeleteGame();
            DeleteGameObject.DeleteGameMethod(game_id);
        }


        public void DeleteMemberServiceMethod(int id)
        {
            DeleteMember DeleteMemberObject = new DeleteMember();
            DeleteMemberObject.DeleteMemberMethod(id);
        }
    }
}
