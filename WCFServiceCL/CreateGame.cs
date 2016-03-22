using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceCL
{
    [DataContract]
    public class CreateGameServiceClass
    {
        [DataMember]
        public int game_id { get; set; }//serialisables

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public Nullable<decimal> payout { get; set; }
    }
}
