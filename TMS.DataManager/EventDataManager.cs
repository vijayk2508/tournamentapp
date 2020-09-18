using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TMS.DTO;
using VISE.Core;
using VISE.Core.Library.Helper;

namespace TMS.DataManager
{
    public class EventDataManager : SqlAPI
    {
        #region Global Variable
        private static readonly string TableName = "TMS_Event";
        private EventDTO dtoEvent;
        #endregion

        #region Constructor
        public EventDataManager(EventDTO currentEvent)
        {
            dtoEvent = currentEvent;
        }

        public EventDataManager()
        {
        }
        #endregion

        #region Save
        public bool Save()
        {
            #region Update
            if (dtoEvent.Event_ID > 0)
            {
                query = "Update ";
                query += TableName;
                query += "set ";
                query += "Event_Image=" + dtoEvent.Event_Image + ",";
                query += "Event_Title=" + dtoEvent.Event_Title + ",";
                query += "Event_Description=" + dtoEvent.Event_Description + " ";
                query += "where Event_ID=" + dtoEvent.Event_ID;
            }
            #endregion

            #region Insert
            else
            {
                query = "insert into ";
                query += TableName;
                query += "(";
                query += "Event_Title,";
                query += "Event_Description,";
                query += "Event_Image,";
                query += "Event_RecordAddedDateTime";
                query += ")";
                query += "values";
                query += "(";
                query += "'" + dtoEvent.Event_Title + "',";
                query += "'" + dtoEvent.Event_Description + "',";
                query += "'" + dtoEvent.Event_Image + "',";
                query += "'" + dtoEvent.Event_RecordAddedDateTime + "'";
                query += ")";
            }
            #endregion

            bStatus = SqlAPI.Save(query) > 0 ? true : false;
            return bStatus;
        }
        #endregion

        #region Delete
        public bool Delete()
        {
            #region Delete query

            query = "Delete from ";
            query += TableName;
            if (dtoEvent.Event_ID > 0)
            {
                query += " where Event_ID=" + dtoEvent.Event_ID;
            }

            #endregion
            bStatus = SqlAPI.Save(query) > 0 ? true : false;
            return bStatus;
        }
        #endregion 

        #region GetAll
        public Collection<EventDTO> EventCollection
        {
            get
            {
                query = "select * from " + TableName;

                Collection<EventDTO> collEvent = new Collection<EventDTO>();

                Collection<DataRow> collDataRow = SqlAPI.GetAll(query);

                if (collDataRow.Count > 0)
                {
                    foreach (DataRow itemRow in collDataRow)
                    {
                        collEvent.Add(new EventDTO()
                        {
                            Event_ID = itemRow.Field<int?>("Event_ID"),
                            Event_Title = itemRow.Field<string>("Event_Title"),
                            Event_Description = itemRow.Field<string>("Event_Description"),
                            Event_Image = itemRow.Field<string>("Event_Image"),
                            Event_RecordAddedDateTime = itemRow.Field<long?>("Event_RecordAddedDateTime"),
                        });
                    }
                }
                return collEvent;
            }
        }
        #endregion
    }
}
