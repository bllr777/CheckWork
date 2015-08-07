using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class DetailsManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static LotteryGameDetail GetItem(int LotteryGameId)
        {
            //notes:    call DAL to retrieve single item
            return DetailsDAL.GetItem(LotteryGameId);
        }
        #region INSERT, UPDATE
        public static int Save(LotteryGameDetail detailsToSave)
        {
            LotteryGameDetail game = new LotteryGameDetail();
            game.LotteryGameId = detailsToSave.LotteryGameId;

            int lotteryGameId = SaveGame(detailsToSave);
            detailsToSave.LotteryGameId = lotteryGameId;

            if (detailsToSave.GameDescription != null)
                game.GameDescription = detailsToSave.GameDescription;

            if (detailsToSave.HowToPlay != null)
                game.HowToPlay = detailsToSave.HowToPlay;

            if (detailsToSave.Cost != null)
                game.Cost = detailsToSave.Cost;

            return DetailsDAL.Save(detailsToSave);
        }
        #endregion

        #region DELETE
        public static bool Delete(int lotteryGameId)
        {
            if (DetailsDAL.Delete(lotteryGameId))
            {
                //notes:    call DAL to delete game record
                return LotteryGameManager.Delete(lotteryGameId);
            }
            else
                return false;

        }
        #endregion
        private static int SaveGame(LotteryGameDetail detailsToSave)
        {
            LotteryGameValue tempGame = new LotteryGameValue();
            tempGame.LotteryGameId = detailsToSave.LotteryGameId;

            if (detailsToSave.GameName != null)                                               
                tempGame.GameName = detailsToSave.GameName;

            if (detailsToSave.GameNameAbbrev != null)
                tempGame.GameNameAbbrev = detailsToSave.GameNameAbbrev;

            return LotteryGameManager.Save(tempGame);
        }

       
    }
}