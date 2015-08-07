using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AstonTech.Lottery.Services.Faults
{
    [DataContract(Name= "LotteryLookupServiceFault")]
    public class LotteryLookupServiceFault
    {
        [DataMember]
        public string ErrorMessage { get; set; }

        #region CONSTRUCTOR

        public LotteryLookupServiceFault(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        #endregion
    }
}