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
    public class WinDAL
    {
        #region INSERT AND UPDATE
        public static int Save(Win winToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid WinId - if exists then UPDATE , else INSERT
            if (winToSave.WinId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWin", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@WinId", winToSave.WinId);


                    if (winToSave.WinValue != null)
                        myCommand.Parameters.AddWithValue("@Win", winToSave.WinValue);
                    ;

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
        public static bool Delete(int winId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWin", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@WinId", winId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                myConnection.Close();
            }
            return result > 0;


        }
        #endregion
        public static Win GetItem(int winId)
        {
            Win tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWin", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@WinId", winId);


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


        public static WinCollection GetCollection(int winId)
        {
            WinCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWin", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@WinId", winId);


                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new WinCollection();
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

        private static Win FillDataRecord(IDataRecord myDataRecord)
        {
            Win myObject = new Win();

            myObject.WinId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("WinId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Win")))
                myObject.WinValue = myDataRecord.GetString(myDataRecord.GetOrdinal("Win"));




            return myObject;
        }
    }
}