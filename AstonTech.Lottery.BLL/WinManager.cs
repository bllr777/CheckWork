using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class WinManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static Win GetItem(int winId)
        {
            //notes:    call DAL to retrieve single item
            return WinDAL.GetItem(winId);
        }


        #region RETRIEVE COLLECTION

        public static WinCollection GetCollection(int winId)
        {
            return WinDAL.GetCollection(winId);
        }
        #endregion
        #region INSERT, UPDATE
        public static int Save(Win winToSave)
        {
            Win win = new Win();
            win.WinId = winToSave.WinId;

            if (winToSave.WinId > 0)
                win.WinId = winToSave.WinId;

            if (winToSave.WinValue != null)
                win.WinValue = winToSave.WinValue;

            return WinDAL.Save(winToSave);
        }
        #endregion

        #region DELETE
        public static bool Delete(int winId)
        {
            //notes:    call DAL to delete game record
            return WinDAL.Delete(winId);
        }
        #endregion
        
    }
}