using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AstonTech.Lottery.Services.DataContracts
{
    
        [CollectionDataContract(Name= "LotteryGameDTOCollection")]
        public class LotteryGameDTOCollection : Collection<LotteryGameDTO> { }

        [CollectionDataContract(Name = "DrawingDTOCollection")]
        public class DrawingDTOCollection : Collection<DrawingDTO> { }
    
}