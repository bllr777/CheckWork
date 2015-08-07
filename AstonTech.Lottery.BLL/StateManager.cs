using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class StateManager
    {
        /// <summary>
        /// Gets a single item instance of a Game. If no record, Game object will be null.
        /// </summary>
        /// <param name="LotteryId">Integer Value</param>
        /// <returns>Valid object if exists, else null object</returns>
        public static StateName GetItem(int stateId)
        {
            //notes:    call DAL to retrieve single item
            return StateDAL.GetItem(stateId);
        }


        #region RETRIEVE COLLECTION

        public static StateNameCollection GetCollection(int stateId)
        {
            return StateDAL.GetCollection(stateId);
        }
        #endregion
        #region INSERT, UPDATE
        public static int Save(StateName stateToSave)
        {
            StateName State = new StateName();
            State.StateId = stateToSave.StateId;

            if (stateToSave.StateId > 0)
                State.StateId = stateToSave.StateId;

            if (stateToSave.State != null)
                State.State = stateToSave.State;

            if (stateToSave.StateAbbreviation != null)
                State.StateAbbreviation = stateToSave.StateAbbreviation;

            return StateDAL.Save(stateToSave);
        }
        #endregion

        #region DELETE
        public static bool Delete(int stateId)
        {
            //notes:    call DAL to delete game record
            return StateDAL.Delete(stateId);
        }
        #endregion
    }
}