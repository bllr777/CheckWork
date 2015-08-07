using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;
using AstonTech.Lottery.Common;

namespace AstonTech.Lottery
{
    public static class LotteryGameManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static LotteryGameValue GetItem2(int lotteryGameId)
        {
            //notes:    call DAL to retrieve single item
            return LotteryGameDAL.GetItem(lotteryGameId);
        }
        #region RETRIEVE SINGLE ITEM
        public static LotteryGameValue GetItem( int lotteryId)
        {
            return new LotteryGameValue();
        }

        #endregion

        #region RETRIEVE COLLECTION

        public static LotteryGameCollection GetCollection()
        {
            LotteryGameCollection gameCollection = LotteryGameDAL.GetCollection();

            return gameCollection;
        }
        #endregion

        #region RETRIEVE COLLECTION By Name

        public static LotteryGameCollection GetCollectionByName()
        {

            return GetCollectionByName();
        }
        #endregion

        #region INSERT, UPDATE
        public static int Save2(int lotteryId, LotteryGameValue gameToSave)
        {
            int returnValue;
            returnValue = LotteryGameDAL.Save2(lotteryId, gameToSave);

            return returnValue;
        }
        public static int Save(LotteryGameValue lotteryGameId)
        {
            int returnValue;
            returnValue = LotteryGameDAL.Save(lotteryGameId);

            return returnValue;
        }
        #endregion

        #region DELETE
        public static bool Delete(int lotteryGameId)
        {
            //notes:    call DAL to delete game record
            return LotteryGameDAL.Delete(lotteryGameId);
        }
        #endregion

        #region SERVICE SAVE

        public static int SaveGame(int lotteryId, LotteryGameValue gameToSave)
        {
            //notes:    instantiate BrokenRules collection and check for any validation errors
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (lotteryId <= 0)
                saveBrokenRules.Add("Lottery", "Invalid Lottery Game Id");

            if (gameToSave == null)
                saveBrokenRules.Add("Game Name", "Invalid GameName objects.");

            else
            {
                if (string.IsNullOrEmpty(gameToSave.GameName))
                    saveBrokenRules.Add("Game Name", "Game Name is required");
            }

            if (saveBrokenRules.Count() > 0)
                throw new BLLException("Validation rules failed.", saveBrokenRules);
            else
                return LotteryGameDAL.Save2(lotteryId, gameToSave);
        }

        #endregion
    }


}
