using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public class DrawingNumber : BaseBO
    {

        public DrawingNumber() 
        {
            
        }

        public DrawingNumber(int drawgingTypeId)
        {
            this.DrawingTypeId = DrawingTypeId;
          
        }

        public DrawingNumber(int drawingNumberId, int drawingNumberValue, int drawingTypeId, int lotteryDrawingId)
    {
        this.DrawingNumberId = drawingNumberId;
        this.DrawingNumberValue = drawingNumberValue;
        this.DrawingTypeId = drawingTypeId;
        this.LotteryDrawingId = lotteryDrawingId;
    }

    
        public int DrawingNumberId { get; set;}
        public int DrawingNumberValue { get; set; }
        public int DrawingTypeId { get; set; }
        public int LotteryDrawingId { get; set; }
        public string BallType { get; set; }

     
    }
}
