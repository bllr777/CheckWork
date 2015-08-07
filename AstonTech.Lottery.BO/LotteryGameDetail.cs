using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public class LotteryGameDetail : BaseBO
    {
        public LotteryGameDetail()
        {

        }
        public LotteryGameDetail(int lotteryGameDetailId, string gameDescription, string howtoPlay, string cost)
        {
            this.LotteryGameDetailId = lotteryGameDetailId;
            this.GameDescription = gameDescription;
            this.HowToPlay = howtoPlay;                                                                                                                                                   
            this.Cost = cost;
        }

        public int LotteryGameId { get; set; }
        public int LotteryGameDetailId { get; set; }
        public string GameNameAbbrev { get; set; }
        public string GameDescription { get; set; }
        public string GameName { get; set; }
        public string HowToPlay { get; set; }
        public string Cost { get; set;  }



    }
}
