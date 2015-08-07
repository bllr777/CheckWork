using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using AstonTech.Lottery.Services.DataContracts;
using AstonTech.Lottery.Services.Faults;

namespace AstonTech.Lottery.Services
{
    [ServiceContract]
    interface IDrawingService
    {

        #region DRAWING 

        [Description("Gets a collection of Drawing records in JSON format.")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Drawing/Collection/")]
        DrawingDTOCollection GetDrawing();



        [Description("Gets a single instance of the drawing. Pass in the DrawingId as a parameter.")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Drawing/Item/{DrawingId}")]
        DrawingDTOCollection GetDrawings(string drawingId);

        [Description("Deletes a drawing.")]
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat= WebMessageFormat.Json, UriTemplate = "Drawing/Item/{DrawingId}")]
        bool DeleteDrawing(string drawingId);

        [Description("Saves a drawing.")]
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Drawing/Item/{DrawingId}")]
        DrawingDTO SaveDrawing(string drawingId, DrawingDTO drawingToSave);

        [Description("Saves a drawing.")]
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Drawing/Item/{DrawingId}")]
        DrawingDTO SavesDrawing(string drawingId, DrawingDTO drawingToSave);
        #endregion

    }
}
