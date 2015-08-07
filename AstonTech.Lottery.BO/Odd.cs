using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
   public class Odd : BaseBO
    {
       public Odd()
       {

       }
       public Odd(int oddId, string oddValue)
       {
           this.OddId = oddId;
           this.OddValue = oddValue;
       }
       public int OddId { get; set; }
        public string OddValue { get; set; }
    }
}
