using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class MatchManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static Match GetItem(int matchId)
        {
            //notes:    call DAL to retrieve single item
            return MatchDAL.GetItem(matchId);
        }


        #region RETRIEVE COLLECTION

        public static MatchCollection GetCollection(int matchId)
        {
            return MatchDAL.GetCollection(matchId);
        }
        #endregion
        #region INSERT, UPDATE
        public static int Save(Match matchToSave)
        {
            Match match = new Match();
            match.MatchId = matchToSave.MatchId;

            if (matchToSave.MatchId > 0)
                match.MatchId = matchToSave.MatchId;

            if (matchToSave.MatchValue != null)
                match.MatchValue = matchToSave.MatchValue;

            return MatchDAL.Save(matchToSave);
        }
        #endregion

        #region DELETE
        public static bool Delete(int matchId )
        {
            //notes:    call DAL to delete game record
            return MatchDAL.Delete(matchId);
        }
        #endregion
    }
}