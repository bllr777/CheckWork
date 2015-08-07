using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AstonTech.Lottery.Services.DataContracts
{
        [DataContract(Name = "DrawingDTO")]
    public class DrawingDTO
    {
            [DataMember]
            public int LotteryDrawingId { get; set; }

            [DataMember]
            public int LotteryGameId { get; set; }
            [DataMember]
            public string DrawingDate { get; set; }
            [DataMember]
            public string PrizeAmount { get; set; }
    }
}