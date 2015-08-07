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
    public class DrawingTypeDAL
    {
        public static DrawingType GetItem(int DrawingTypeId)
        {
            DrawingType tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetDrawingType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@DrawingTypeId", DrawingTypeId);

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


        public static DrawingTypeCollection GetCollection(DrawingTypeEnum ballType)
        {
            DrawingTypeCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetDrawingType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@BallType", ballType.ToString());

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new DrawingTypeCollection();
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

        private static DrawingType FillDataRecord(IDataRecord myDataRecord)
        {
            DrawingType myObject = new DrawingType();

            myObject.DrawingTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallType")))
                myObject.BallType = myDataRecord.GetString(myDataRecord.GetOrdinal("BallType"));

            return myObject;
        }
    }
}
