using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceCL.Create
{
    [ServiceContract]
    public interface IServe
    {
        [OperationContract]
        void CreateGameServiceMethod(Game game);//Here give many operation contracts.

        [OperationContract]
        void CreateMemberServiceMethod(Member member);

        [OperationContract]
        virtual void DeleteGameServiceMethod(int game_id);

        [OperationContract]
        virtual void DeleteMemberServiceMethod(int id);
    }
}
