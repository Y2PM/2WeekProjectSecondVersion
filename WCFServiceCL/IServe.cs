﻿using DBLayer;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFServiceCL
{
    [ServiceContract]
    public interface IServe
    {
        [OperationContract]
        void CreateGameServiceMethod(Game game);

        [OperationContract]
        void CreateMemberServiceMethod(Member member);

        [OperationContract]
        void DeleteGameServiceMethod(int game_id);

        [OperationContract]
        void DeleteMemberServiceMethod(int id);

        [OperationContract]
        List<Game> ReadAllGamesServiceMethod();

        [OperationContract]
        Game ReadSpecificGameServiceMethod(int id);

        [OperationContract]
        List<Member> ReadAllMembersServiceMethod();

        [OperationContract]
        Member ReadSpecificMemberServiceMethod(int id);

        [OperationContract]
        List<Log> ReadAllLogsServiceMethod();

        [OperationContract]
        void UpdateGameServiceMethod(Game gameToUpdate);

        [OperationContract]
        void UpdateMemberServiceMethod(Member memberToUpdate);

        [OperationContract]
        bool LoginServiceMethod(string username, string password);

        [OperationContract]
        decimal ReadGamePayout(string gamename);

        [OperationContract]
        decimal ReadMemberAccount(int memberid);

        [OperationContract]
        void UpdateMemberAccount(int memberid, decimal currentbalance, decimal payout);

        [OperationContract]
        int ReadCurrentMember(string user, string pass);

        [OperationContract]
        bool ReadMemberNewUsername(string username);

        [OperationContract]
        bool UpdateMemberAccountPay(int memberid, decimal currentbalance, decimal price);

        [OperationContract]
        void UpdateMemberAccountBalance(int memberid, decimal currentbalance, decimal addtoaccount);

        [OperationContract]
        decimal ReadGamePrice(string gamename);

        [OperationContract]
        bool UpdateMemberPassword(int currentuser, string p1, string p2);
    }
}
