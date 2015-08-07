using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;
using AstonTech.Lottery.Common;
using AstonTech.Lottery.Common.Extensions;

namespace AstonTech.Lottery
{
    public static class DrawingManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static LotteryDrawing GetItem(int lotteryDrawingId)
        {
            //notes:    call DAL to retrieve single item
            return LotteryDrawingDAL.GetItem(lotteryDrawingId);
        }


        #region RETRIEVE COLLECTION

        public static LotteryDrawingCollection GetCollection(int lotteryId)
        {
            return LotteryDrawingDAL.GetCollection(lotteryId);
        }
        #endregion
        #region INSERT, UPDATE
        public static int Save(LotteryDrawing drawingToSave)
        {
            LotteryDrawing drawing = new LotteryDrawing();
            drawing.LotteryGameId = drawingToSave.LotteryGameId;

            if (drawingToSave.LotteryGameId > 0)
                drawing.LotteryGameId = drawingToSave.LotteryGameId;

            if (drawingToSave.DrawingDate != null)
                drawing.DrawingDate = drawingToSave.DrawingDate;

            if (drawingToSave.PrizeAmount != null)
                drawing.PrizeAmount = drawingToSave.PrizeAmount;

            return  LotteryDrawingDAL.Save(drawingToSave);
        }

        public static int SaveDrawing(int lotteryDrawingId, LotteryDrawing drawingToSave)
        {
            //notes:    instantiate BrokenRules collection and check for any validation errors
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (lotteryDrawingId <= 0)
                saveBrokenRules.Add("Drawing", "Drawing must be associated with a valid Drawing");

            if (drawingToSave == null)
                saveBrokenRules.Add("Drawing", "Invalid Drawing object.");

            else
            {
                if (string.IsNullOrEmpty(drawingToSave.PrizeAmount))
                    saveBrokenRules.Add("PrizeAmount", "Value is required");
            }

            if (saveBrokenRules.Count() > 0)
                throw new BLLException("Validation rules failed.", saveBrokenRules);
            else
            {
                drawingToSave.PrizeAmount = new LotteryDrawing { LotteryDrawingId = lotteryDrawingId };
                return LotteryDrawingDAL.Save(drawingToSave);
            }
        
        }
        #endregion
        public static bool Delete1(int lotteryDrawingId)
        {
            return DrawingNumberDAL.Delete(lotteryDrawingId);
        }
        #region DELETE
        #region DELETE

        public static bool Delete(int lotteryDrawingId)
        {
            if (DrawingNumberDAL.Delete(lotteryDrawingId))
            {
                //notes:    call DAL to delete game record
                return LotteryDrawingDAL.Delete(lotteryDrawingId);
            }

           if(LotteryDrawingDAL.Delete(lotteryDrawingId))
           {
               return true;
           }
            
                return false;
            

        }
        #endregion
        #endregion
    }
}