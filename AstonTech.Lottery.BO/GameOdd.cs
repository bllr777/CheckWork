using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public  class GameOdd : BaseBO
    {
       
        public GameOdd(int gameOddId, int matchId, int oddId, int winId) 
        {
            this.GameOddId = gameOddId;
            this.MatchId = matchId;
            this.OddId = oddId;
            this.WinId = winId;


        }
        public int GameOddId { get; set; }
        public int LotteryGameId { get; set; }
        public int MatchId { get; set; }
        public int OddId { get; set; }
        public int WinId { get; set; }
    }
} 
