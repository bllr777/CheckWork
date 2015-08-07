using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using AstonTech.Lottery.Services.DataContracts;
using AstonTech.Lottery.Services.Faults;

namespace AstonTech.Lottery.Services.ServiceContracts
{
    [ServiceContract]
    interface ILotteryLookupService
    {
        #region LOTTERYGAME

        [OperationContract]
       LotteryGameDTOCollection GetLotteryGameCollection();

        [OperationContract]
        LotteryGameDTO GetLotteryGame(int lotteryId);

        [OperationContract]
        [FaultContract(typeof(LotteryLookupServiceFault))]
        void DeleteLotteryGame(int lotteryId);

        [OperationContract]
        [FaultContract(typeof(LotteryLookupServiceFault))]
        void SaveLotteryGame(LotteryGameDTO gameToSave);

        #endregion
    }
}
