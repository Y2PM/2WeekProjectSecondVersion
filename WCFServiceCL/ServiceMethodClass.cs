using DBLayer;
using DBLayer.Create;
using DBLayer.Delete;
using DBLayer.Read;
using DBLayer.Update;
using System.Collections.Generic;

namespace WCFServiceCL
{
    public class ServiceMethodClass : IServe
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

        public List<Game> ReadAllGamesServiceMethod()
        {
            ReadGame ReadGameObject = new ReadGame();
            return ReadGameObject.ReadAllGames();
        }

        public Game ReadSpecificGameServiceMethod(int id)
        {
            ReadGame ReadGameObject = new ReadGame();
            return ReadGameObject.ReadSpecificGame(id);
        }

        public List<Member> ReadAllMembersServiceMethod()
        {
            ReadMember ReadMemberObject = new ReadMember();
            return ReadMemberObject.ReadAllMembers();
        }

        public Member ReadSpecificMemberServiceMethod(int id)
        {
            ReadMember ReadMemberObject = new ReadMember();
            return ReadMemberObject.ReadSpecificMember(id);
        }

        public void UpdateGameServiceMethod(Game gameToUpdate)
        {
            UpdateGame UpdateGameObject = new UpdateGame();
            UpdateGameObject.UpdateGameMethod(gameToUpdate);
        }

        public void UpdateMemberServiceMethod(Member memberToUpdate)
        {
            UpdateMember UpdateMemberObject = new UpdateMember();
            UpdateMemberObject.UpdateMemberMethod(memberToUpdate);
        }

        public bool LoginServiceMethod(string username, string password)
        {
            ReadMember ReadMemberObject = new ReadMember();
            return ReadMemberObject.login(username, password);
        }
    }
}
