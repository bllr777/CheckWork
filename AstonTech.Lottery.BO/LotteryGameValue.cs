 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{

    public class LotteryGameValue : BaseBO
    {
        public LotteryGameValue()
        {

        }
        public LotteryGameValue(int lotteryGameId, string gameName, string gameAbbreviation)
        {
            this.LotteryGameId = lotteryGameId;
            this.GameName = gameName;
            this.GameNameAbbrev = gameAbbreviation;
        }
        public int LotteryGameId { get; set; }
        public string GameName { get; set; }
        public string GameNameAbbrev { get; set; }
        public string GetItem { get; set; }

        public string GetGame()
        {
                return this.GameName;
        }


        public string GetGameAbbreviation()
        {
            return this.GameNameAbbrev;
        }

        public string GetGameName
        {
            get
            {
                return GameName + " " + GameNameAbbrev;
            }
        }
    }
}


