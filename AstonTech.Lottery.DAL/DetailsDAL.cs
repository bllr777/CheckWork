using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AstonTech.Lottery;

namespace AstonTech.Lottery.DAL
{
    public class DetailsDAL
    {
        #region INSERT AND UPDATE
        public static int Save(LotteryGameDetail detailsToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid LotteryGameId - if exists then UPDATE , else INSERT
            if (detailsToSave.LotteryGameDetailId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryGameDetail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@LotteryGameId", detailsToSave.LotteryGameId);

                    if (detailsToSave.GameDescription != null)
                        myCommand.Parameters.AddWithValue("@GameDescription", detailsToSave.GameDescription);
                    if (detailsToSave.HowToPlay != null)
                        myCommand.Parameters.AddWithValue("@HowToPlay", detailsToSave.HowToPlay);
                    if (detailsToSave.Cost != null)
                        myCommand.Parameters.AddWithValue("@Cost", detailsToSave.Cost);

                    //notes:    add return output parameter to command object
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    //notes:    get return value from stored procedure and return Id
                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;

        }
        #endregion

        #region DELETE
        public static bool Delete(int lotteryGameId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryGameDetail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@LotteryGameId", lotteryGameId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                myConnection.Close();
            }
            return result > 0;


        }
        #endregion

        #region GET ITEM
        public static LotteryGameDetail GetItem(int LotteryGameId)
        {
            LotteryGameDetail tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetDetails", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryGameId", LotteryGameId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tempItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                }
                myConnection.Close();
            }
            return tempItem;
        }
        #endregion

        #region GET COLLECTION
        public static LotteryGameDetailCollection GetCollection()
        {
            LotteryGameDetailCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetDetails", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);


                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new LotteryGameDetailCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }

                }
            }
            return tempList;


        }
        #endregion

        #region FILL DATA
        private static LotteryGameDetail FillDataRecord(IDataRecord myDataRecord)
        {
            LotteryGameDetail myObject = new LotteryGameDetail();

            myObject.LotteryGameDetailId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryGameDetailId"));
            myObject.LotteryGameId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryGameId"));
            

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GameDescription")))
                myObject.GameDescription = myDataRecord.GetString(myDataRecord.GetOrdinal("GameDescription"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HowToPlay")))
                myObject.HowToPlay = myDataRecord.GetString(myDataRecord.GetOrdinal("HowToPlay"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Cost")))
                myObject.Cost = myDataRecord.GetString(myDataRecord.GetOrdinal("Cost"));

            return myObject;
        }
        #endregion
    }
}

