using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using AstonTech.Lottery.Services.DataContracts;
using AstonTech.Lottery.Common;
using AstonTech.Lottery.Common.Extensions;
using AstonTech.Lottery;

namespace AstonTech.Lottery.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DrawingService : IDrawingService
    {

        #region Drawing
        
        public DrawingDTOCollection GetDrawing()
        {
            LotteryDrawingCollection drawingList = DrawingManager.GetCollection();
            return this.DrawingCollectionToDTO(drawingList);
        }

        public bool DeleteDrawing(string drawingId)
        {
            return DrawingManager.Delete(drawingId.ToInt());
        }

        public DrawingDTO GetDrawing(string drawingId)
        {
            LotteryDrawing drawing = DrawingManager.GetItem(drawingId.ToInt());
            return this.DrawingItemToDTO(drawing);
        }

        public DrawingDTOCollection GetDrawings(string drawingId)
        {
            LotteryDrawingCollection drawingList = DrawingManager.GetCollection(drawingId.ToInt());
            return this.DrawingCollectionToDTO(drawingList);
        }

        public DrawingDTO SaveDrawing (string drawingId, DrawingDTO drawingToSave)
        {
            int lotteryId= DrawingManager.Save(drawingId.ToInt(), this DTOItemToSave(drawingToSave));

            LotteryDrawing updatedItem = DrawingManager.GetItem(drawingId.ToInt());
            return this.DrawingItemToDTO(updatedItem);
        }

        //public DrawingDTO SavesDrawing (string drawingId, DrawingDTO drawingToSave)
        //{

        //}

        #endregion


        #region HYDRATE OBJECTS AND DTOs
        
        private DrawingDTO DrawingItemToDTO(LotteryDrawing drawingDTO)
        {
            DrawingDTO tempItem = new DrawingDTO();

            if (drawingDTO !=null)
            {
                tempItem.LotteryDrawingId = LotteryDrawing.LotteryDrawingId;

                if (!string.IsNullOrEmpty(LotteryDrawing.PrizeAmount))
                    tempItem.PrizeAmount = LotteryDrawing.PrizeAmount;

                if (!string.IsNullOrEmpty(LotteryDrawing.DrawingDate.ToDate()))
                    tempItem.DrawingDate = LotteryDrawing.DrawingDate.ToDate();

            }

            return tempItem;
        }

        private DrawingDTOCollection DrawingCollectionToDTO(LotteryDrawingCollection drawingCollection)
        {
            DrawingDTOCollection tempList = new DrawingDTOCollection();
            DrawingDTO tempItem;

            if(drawingCollection !=null)
            {
                foreach (LotteryDrawing item in drawingCollection)
                {
                    tempItem = new DrawingDTO();

                    tempItem.LotteryDrawingId = item.LotteryDrawingId;

                    tempList.Add(tempItem);
                }

            }
            return tempList;
        }

        //private DrawingDTO DrawingItemToDTO(LotteryDrawing drawing)
        //{

        //}

        #endregion
    }
}