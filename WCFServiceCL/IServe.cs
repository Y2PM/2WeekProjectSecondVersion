using DBLayer;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFServiceCL
{
    [ServiceContract]
    public interface IServe
    {
        [OperationContract]
        void CreateGameServiceMethod(Game game);//Here give many operation contracts.

        [OperationContract]
        void CreateMemberServiceMethod(Member member);

        [OperationContract]
        void DeleteGameServiceMethod(int game_id);//

        [OperationContract]
        void DeleteMemberServiceMethod(int id);//

        [OperationContract]
        List<Game> ReadAllGamesServiceMethod();

        [OperationContract]
        Game ReadSpecificGameServiceMethod(int id);

        [OperationContract]
        List<Member> ReadAllMembersServiceMethod();

        [OperationContract]
        Member ReadSpecificMemberServiceMethod(int id);

        [OperationContract]
        void UpdateGameServiceMethod(Game gameToUpdate);

        [OperationContract]
        void UpdateMemberServiceMethod(Member memberToUpdate);
    }
}
