using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public class LotteryGameState : BaseBO
    {
        public LotteryGameState(int lotteryGameStateId, int lotteryGameId, int stateId)
        {
            this.LotteryGameStateId = lotteryGameStateId;
            this.StateId = stateId;
        }
        public int LotteryGameStateId { get; set; }
        public int LotteryGameId { get; set; }
        public int StateId { get; set; }
    }
}
