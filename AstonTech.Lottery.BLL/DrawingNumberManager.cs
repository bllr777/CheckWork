using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class DrawingNumberManager
    {
        public static DrawingNumber GetItem(int drawingNumberId)
        {
            //notes:    call DAL to retrieve single item
            return DrawingNumberDAL.GetItem(drawingNumberId);
        }
        #region INSERT, UPDATE
        public static int Save(DrawingNumber gameToSave)
        {
            int returnValue;
            returnValue = DrawingNumberDAL.Save(gameToSave);

            return returnValue;
        }
        #endregion
        #region RETRIEVE COLLECTION

        public static DrawingNumberCollection GetCollection(int lotteryDrawingId )
        {
            return DrawingNumberDAL.GetCollection(lotteryDrawingId);
        }
        #endregion


    }
}
