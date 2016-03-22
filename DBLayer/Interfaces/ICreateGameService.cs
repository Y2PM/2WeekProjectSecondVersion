using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Interfaces
{
    [ServiceContract]
    public interface ICreateGameService
    {
        [OperationContract]
        void CreateGameMethod(Game game);
    }
}
