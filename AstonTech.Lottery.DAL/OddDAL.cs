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
    public class OddDAL
    {
        #region INSERT AND UPDATE
        public static int Save(Odd  oddToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            // notes:       check for valid OddId - if exists then UPDATE , else INSERT
            if (oddToSave.OddId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteOdd", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@OddId", oddToSave.OddId);


                    if (oddToSave.OddValue != null)
                        myCommand.Parameters.AddWithValue("@Match", oddToSave.OddValue);
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
        public static bool Delete(int oddId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteOdd", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@OddId", oddId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                myConnection.Close();
            }
            return result > 0;


        }
        #endregion
        public static Odd GetItem(int OddId)
        {
            Odd tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetOdd", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@OddId", OddId);


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


        public static OddCollection GetCollection(int oddId)
        {
            OddCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetOdd", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@OddId", oddId);


                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new OddCollection();
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

        private static Odd FillDataRecord(IDataRecord myDataRecord)
        {
            Odd myObject = new Odd();

            myObject.OddId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("OddId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Odd")))
                myObject.OddValue = myDataRecord.GetString(myDataRecord.GetOrdinal("Odd"));




            return myObject;
        }
    }
}