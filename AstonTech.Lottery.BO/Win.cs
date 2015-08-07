using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public class Win : BaseBO
    {
        public Win()
        {

        }
        public Win(int winId, string winValue)
        {
            this.WinId = winId;
            this.WinValue = winValue;
        }
        public int WinId { get; set; }
        public string WinValue { get; set; }
    }
}
