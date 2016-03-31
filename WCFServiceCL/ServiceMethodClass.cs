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
        GroupProjectEntities context = new GroupProjectEntities();

        public void CreateGameServiceMethod(Game game)
        {
            CreateGame CreateGameObject = new CreateGame(context);
            CreateGameObject.CreateGameMethod(game);
        }

        public void CreateMemberServiceMethod(Member member)
        {
            CreateMember CreateMemberObject = new CreateMember(context);
            CreateMemberObject.CreateMemberMethod(member);
        }

        public void DeleteGameServiceMethod(int game_id)
        {
            DeleteGame DeleteGameObject = new DeleteGame(context);
            DeleteGameObject.DeleteGameMethod(game_id);
        }

        public void DeleteMemberServiceMethod(int id)
        {
            DeleteMember DeleteMemberObject = new DeleteMember(context);
            DeleteMemberObject.DeleteMemberMethod(id);
        }

        public List<Game> ReadAllGamesServiceMethod()
        {
            ReadGame ReadGameObject = new ReadGame(context);
            return ReadGameObject.ReadAllGames();
        }

        public Game ReadSpecificGameServiceMethod(int id)
        {
            ReadGame ReadGameObject = new ReadGame(context);
            return ReadGameObject.ReadSpecificGame(id);
        }

        public List<Member> ReadAllMembersServiceMethod()
        {
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.ReadAllMembers();
        }

        public Member ReadSpecificMemberServiceMethod(int id)
        {
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.ReadSpecificMember(id);
        }

        public List<Log> ReadAllLogsServiceMethod()
        {
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.ReadAllLogs();
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
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.login(username, password);
        }

        public decimal ReadGamePayout(string gamename)
        {
            ReadGame ReadGameObject = new ReadGame(context);
            return ReadGameObject.ReadGamePayout(gamename);
        }

        public decimal ReadMemberAccount(int memberid)
        {
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.ReadMemberAccount(memberid);
        }

        public void UpdateMemberAccount(int memberid, decimal currentbalance, decimal payout)
        {
            UpdateMember UpdateMemberObject = new UpdateMember();
            UpdateMemberObject.UpdateMemberAccount(memberid, currentbalance, payout);
        }

        public int ReadCurrentMember(string user, string pass)
        {
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.ReadCurrentMember(user, pass);
        }

        public bool ReadMemberNewUsername(string user)
        {
            ReadMember ReadMemberObject = new ReadMember(context);
            return ReadMemberObject.ReadMemberNewUsername(user);
        }

        public bool UpdateMemberAccountPay(int memberid, decimal currentbalance, decimal price)
        {
            UpdateMember UpdateMemberObject = new UpdateMember();
            return UpdateMemberObject.UpdateMemberAccountPay(memberid, currentbalance, price);
        }

        public void UpdateMemberAccountBalance(int memberid, decimal currentbalance, decimal addtoaccount)
        {
            UpdateMember UpdateMemberObject = new UpdateMember();
            UpdateMemberObject.UpdateMemberAccountBalance(memberid, currentbalance, addtoaccount);
        }

        public decimal ReadGamePrice(string gamename)
        {
            ReadGame ReadGameObject = new ReadGame(context);
            return ReadGameObject.ReadGamePrice(gamename);
        }
    }
}
