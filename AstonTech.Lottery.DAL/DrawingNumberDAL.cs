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
    public class DrawingNumberDAL
    {
        #region INSERT AND UPDATE
        public static int Save(DrawingNumber numberToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid LotteryGameId - if exists then UPDATE , else INSERT
            if (numberToSave.DrawingNumberId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteDrawingNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@DrawingTypeId", numberToSave.DrawingTypeId);
                    myCommand.Parameters.AddWithValue("@DrawingNumberValue", numberToSave.DrawingNumberValue);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", numberToSave.LotteryDrawingId);

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
        public static DrawingNumber GetItem(int drawingNumberId)
        {
            DrawingNumber tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetDrawingNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@DrawingNumberId", drawingNumberId);


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

        #region DELETE
        public static bool Delete(int lotteryDrawingId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteDrawingNumber", myConnection))
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
        public static DrawingNumberCollection GetCollection(int LotteryDrawingId)
        {
            DrawingNumberCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetDrawingNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", LotteryDrawingId);
                  

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new DrawingNumberCollection();
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

        private static DrawingNumber FillDataRecord(IDataRecord myDataRecord)
        {
            DrawingNumber myObject = new DrawingNumber();

            myObject.DrawingNumberId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingNumberId"));
            myObject.LotteryDrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryDrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingNumberValue")))
                myObject.DrawingNumberValue = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingNumberValue"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallType")))
                myObject.BallType = myDataRecord.GetString(myDataRecord.GetOrdinal("BallType"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingTypeId")))
                myObject.DrawingTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingTypeId"));


            return myObject;
        }
    }
}