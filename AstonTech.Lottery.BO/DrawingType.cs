using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.Lottery
{
    public class DrawingType 

    {

        public DrawingType()
        {

        }
        public DrawingType (int drawingTypeId, string ballType)
        {
            this.DrawingTypeId = drawingTypeId;
            this.BallType = ballType;
        }
     
        public int DrawingTypeId { get; set; }
        public string BallType { get; set; }
        public int DrawingNumberId { get; set; }

    }
}
