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
    public class LotteryDrawingDAL
    {
        #region INSERT AND UPDATE
        public static int Save(LotteryDrawing drawingToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid LotteryGameId - if exists then UPDATE , else INSERT
            if (drawingToSave.LotteryDrawingId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@LotteryGameId", drawingToSave.LotteryGameId);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", drawingToSave.LotteryDrawingId);
                   

                    if (drawingToSave.PrizeAmount != null)
                        myCommand.Parameters.AddWithValue("@PrizeAmount", drawingToSave.PrizeAmount);
                    if (drawingToSave.DrawingDate != null)
                        myCommand.Parameters.AddWithValue("@DrawingDate", drawingToSave.DrawingDate);

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
        public static bool Delete(int lotteryDrawingId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", lotteryDrawingId);
                   

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                myConnection.Close();
            }
            return result > 0;


        }
        #endregion
        public static LotteryDrawing GetItem(int lotteryDrawingId)
        {
            LotteryDrawing tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", lotteryDrawingId);
                    

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


        public static LotteryDrawingCollection GetCollection(int LotteryId, int PageNumber, int RowsPerPage)
        {
            LotteryDrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", 30);
                    myCommand.Parameters.AddWithValue("@LotteryId", LotteryId);
                    myCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
                    myCommand.Parameters.AddWithValue("@RowsPerPage", RowsPerPage);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new LotteryDrawingCollection();
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

        public static LotteryDrawingCollection GetCollection(int lotteryId)
        {
            LotteryDrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollectionByName);
                    myCommand.Parameters.AddWithValue("@LotteryGameId", lotteryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new LotteryDrawingCollection();
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


        private static LotteryDrawing FillDataRecord(IDataRecord myDataRecord)
        {
            LotteryDrawing myObject = new LotteryDrawing();

            myObject.LotteryGameId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryGameId"));
            myObject.LotteryDrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryDrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PrizeAmount")))
                myObject.PrizeAmount = myDataRecord.GetString(myDataRecord.GetOrdinal("PrizeAmount"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));
           

             return myObject;
        }
    }
}