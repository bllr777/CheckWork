using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class OddManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static Odd GetItem(int oddId)
        {
            //notes:    call DAL to retrieve single item
            return OddDAL.GetItem(oddId);
        }


        #region RETRIEVE COLLECTION

        public static OddCollection GetCollection(int oddId)
        {
            return OddDAL.GetCollection(oddId);
        }
        #endregion
        #region INSERT, UPDATE
        public static int Save(Odd oddToSave)
        {
            Odd odd = new Odd();
            odd.OddId = oddToSave.OddId;

            if (oddToSave.OddId > 0)
                odd.OddId = oddToSave.OddId;

            if (oddToSave.OddValue != null)
                odd.OddValue = oddToSave.OddValue;

            return OddDAL.Save(oddToSave);
        }
        #endregion

        #region DELETE
        public static bool Delete(int oddId)
        {
            //notes:    call DAL to delete game record
            return OddDAL.Delete(oddId);
        }
        #endregion
    }
}