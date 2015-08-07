using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AstonTech.Lottery.Services.DataContracts;
using AstonTech.Lottery.Services.Faults;
using AstonTech.Lottery.Services.ServiceContracts;
using AstonTech.Lottery;
using AstonTech.Lottery.Common;

namespace AstonTech.Lottery.Services
{
    public class LotteryLookupService : ILotteryLookupService
    {

        #region GET

        public LotteryGameDTOCollection GetLotteryGameCollection()
        {
            LotteryGameCollection lotteryGameCollection = LotteryGameManager.GetCollection();
            return HydrateLotteryDTO(lotteryGameCollection);
        }

        public LotteryGameDTO GetLotteryGame(int lotteryId)
        {
            LotteryGameValue lotteryGameDTO = LotteryGameManager.GetItem2(lotteryId);
            return HydrateLotteryGameDTO(lotteryGameDTO);
        }


        #endregion

        #region SAVE and DELETE

        public void DeleteLotteryGame(int lotteryId)
        {
            if (lotteryId > 0)
            {
                try
                {
                    if (!LotteryGameManager.Delete(lotteryId))
                        throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault("No records were affected."), "Delete failed.");
                }
                catch (BLLException ex)
                {
                    
                    throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault(ex.Message), "Validation failed.");
                }
            }
                else
                throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault("LotteryGameId was not valid"), "Validation failed.");
            }
        

        public void SaveLotteryGame(LotteryGameDTO gameToSave)
        {
            //notes:    validate values
            if (gameToSave !=null)
            {
                if (gameToSave.LotteryGameId > 0)
                {
                    if (string.IsNullOrEmpty(gameToSave.GameName))
                        throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault("GameName is required"));
                    else
                    {
                        try
                        {
                            LotteryGameManager.SaveGame(gameToSave.LotteryGameId, HydrateLotteryGame(gameToSave));
                        }
                        catch (BLLException ex)
                        {
                            throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault(ex.Message), "Save failed.");
                        }
                    }
                    
                }
                else
                    throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault("Lottery Game Id is required"), "Validation failed.");
            }
                else
                     throw new FaultException<LotteryLookupServiceFault>(new LotteryLookupServiceFault("Lottery Game object is required"), "Validation failed.");
        }

        #endregion

        #region HYDRATE OBJECTS

        private LotteryGameDTOCollection HydrateLotteryDTO(LotteryGameCollection lotteryCollection)
        {
            LotteryGameDTOCollection tempCollection = new LotteryGameDTOCollection();
            
            if (lotteryCollection !=null && lotteryCollection.Count > 0)
            {
                foreach (LotteryGameValue item in lotteryCollection)
                {
                    if (!string.IsNullOrEmpty(item.GameNameAbbrev))
                        tempCollection.Add(new LotteryGameDTO { LotteryGameId = item.LotteryGameId, GameAbbreviation = item.GameNameAbbrev });
                    else
                        tempCollection.Add(new LotteryGameDTO { LotteryGameId = item.LotteryGameId });
                }
            }
            return tempCollection;
        }



        private LotteryGameDTO HydrateLotteryGameDTO(LotteryGameValue lotteryGame)
        {
            LotteryGameDTO tempItem = new LotteryGameDTO();

            if (lotteryGame !=null)
            {
                tempItem.LotteryGameId = lotteryGame.LotteryGameId;

                if (!string.IsNullOrEmpty(lotteryGame.GameName))
                    tempItem.GameName = lotteryGame.GameName;
            }

            return tempItem;
        }

        private LotteryGameValue HydrateLotteryGame(LotteryGameDTO lotteryGameDTO)
        {
            LotteryGameValue tempItem = new LotteryGameValue();

            if(lotteryGameDTO !=null)
            {
                tempItem.LotteryGameId = lotteryGameDTO.LotteryGameId;

                if (!string.IsNullOrEmpty(lotteryGameDTO.GameName))
                    tempItem.GameName = lotteryGameDTO.GameName;
            }

            return tempItem;
        }
        #endregion

    }
}
