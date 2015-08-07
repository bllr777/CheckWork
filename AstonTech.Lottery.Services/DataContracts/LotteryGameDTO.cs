using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AstonTech.Lottery.Services.DataContracts
{
    [DataContract(Name="LotteryGameDTO")]
    public class LotteryGameDTO
    {
        [DataMember]
        public int LotteryGameId { get; set; }

        [DataMember]
        public string GameName { get; set; }

        [DataMember]
        public string GameAbbreviation { get; set; }
    }
}