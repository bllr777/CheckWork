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
    public class LotteryGameDAL
    {
        #region INSERT AND UPDATE
        public static int Save(LotteryGameValue gameToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid LotteryGameId - if exists then UPDATE , else INSERT
            if (gameToSave.LotteryGameId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
               

                    if (gameToSave.GameName != null)
                        myCommand.Parameters.AddWithValue("@GameName", gameToSave.GameName);
                    if (gameToSave.GameName != null)
                        myCommand.Parameters.AddWithValue("@GameAbbreviation", gameToSave.GameNameAbbrev);

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

        #region SAVE 2
        public static int Save2(int lotteryId, LotteryGameValue gameToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid LotteryGameId - if exists then UPDATE , else INSERT
            if (gameToSave.LotteryGameId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    if (gameToSave.GameName != null)
                        myCommand.Parameters.AddWithValue("@GameName", gameToSave.GameName);
                    if (gameToSave.GameName != null)
                        myCommand.Parameters.AddWithValue("@GameAbbreviation", gameToSave.GameNameAbbrev);

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

        #region GET ITEM
        public static LotteryGameValue GetItem(int LotteryGameId)
        {
            LotteryGameValue tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryId", LotteryGameId);

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
        public static LotteryGameCollection GetCollection()
        {
            LotteryGameCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);
                   


                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new LotteryGameCollection();
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
        private static LotteryGameValue FillDataRecord(IDataRecord myDataRecord)
        {
            LotteryGameValue myObject = new LotteryGameValue();

            myObject.LotteryGameId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryGameId"));


            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GameName")))
                myObject.GameName = myDataRecord.GetString(myDataRecord.GetOrdinal("GameName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GameAbbreviation")))
                myObject.GameNameAbbrev = myDataRecord.GetString(myDataRecord.GetOrdinal("GameAbbreviation"));

            return myObject;
        }
        #endregion

        #region DELETE
        public static bool Delete(int lotteryGameId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGame", myConnection))
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

    }
}
