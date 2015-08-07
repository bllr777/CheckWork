using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;

namespace AstonTech.Lottery
{
    public static class DrawingTypeManager
    {

        #region RETRIEVE SINGLE ITEM
        public static DrawingType GetItem(int DrawingTypeId)
        {
            return DrawingTypeDAL.GetItem(DrawingTypeId);
        }

        #endregion

    

   

        #region RETRIEVE COLLECTION

        public static DrawingTypeCollection GetCollection(DrawingTypeEnum ballType)
        {

            DrawingTypeCollection DrawingTypeCollection = DrawingTypeDAL.GetCollection(ballType);

            return DrawingTypeCollection;
        }
        #endregion

    }


}
