using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
   public class Match : BaseBO
    {
       public Match()
       {

       }
       public Match(int matchId, string matchValue)
       {
           this.MatchId = matchId;
           this.MatchValue = matchValue;
       }
       public int MatchId { get; set; }
        public string MatchValue { get; set; }
    }
}
