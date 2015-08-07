using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
   public class StateName : BaseBO
    {
        
       public StateName()
       {

       }
       public StateName(int stateId, string State, string stateAbbreviation)
       {
           this.StateId = stateId;
           this.State = State;
           this.StateAbbreviation = stateAbbreviation;
       }
       public int StateId { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
    }
}
