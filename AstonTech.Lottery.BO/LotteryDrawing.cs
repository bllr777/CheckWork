using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public class LotteryDrawing : BaseBO
    {
        public LotteryDrawing(int lotteryDrawingId, DateTime drawingDate, string prizeAmount)
        {
            this.LotteryDrawingId = lotteryDrawingId;
            this.DrawingDate = drawingDate;
            this.PrizeAmount = prizeAmount;
           
       
        }

        public LotteryDrawing()
        {

        }

        public int LotteryDrawingId { get; set; }
        public int LotteryGameId { get; set; }
        public DateTime DrawingDate { get; set; }
        public string PrizeAmount { get; set; }
        

        public string GetDrawing()
        {

            return "DrawingId:" + this.LotteryDrawingId + " GameId:" + this.LotteryGameId + "  Prize Amount:$" + this.PrizeAmount + "  Drawing Date:" + this.DrawingDate;
           
        }

    }
}
