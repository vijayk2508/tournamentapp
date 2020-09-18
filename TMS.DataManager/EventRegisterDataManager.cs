using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TMS.DTO;
using VISE.Core;
using VISE.Core.Library.Helper;

namespace TMS.DataManager
{
    public class EventRegisterDataManager : SqlAPI
    {
        #region Global Variable
        private static readonly string TableName = "TMS_EventRegister";
        private EventRegisterDTO dtoEventRegister;
        #endregion

        #region Constructor
        public EventRegisterDataManager(EventRegisterDTO currentEventRegister)
        {
            dtoEventRegister = currentEventRegister;
        }

        public EventRegisterDataManager()
        {
        }
        #endregion

        #region Save
        public bool Save()
        {
            #region Update
            if (dtoEventRegister.EventRegister_ID > 0)
            {
                query = "Update ";
                query += TableName;

                query += "set ";
                query += "EventRegister_EventID=" + dtoEventRegister.EventRegister_EventID + ",";
                query += "EventRegister_PlayerID=" + dtoEventRegister.EventRegister_PlayerID + ",";
                query += "EventRegister_PlayerUsername=" + dtoEventRegister.EventRegister_PlayerUsername + ",";
                query += "EventRegister_Status" + dtoEventRegister.EventRegister_Status+ " ";

                query += "where EventRegister_ID=" + dtoEventRegister.EventRegister_ID;
            }
            #endregion

            #region Insert
            else
            {
                query = "Insert into ";
                query += TableName;
                query += "(";
                query += "EventRegister_EventID,";
                query += "EventRegister_PlayerID,";
                query += "EventRegister_PlayerUsername,";
                query += "EventRegister_Status,";
                query += "EventRegister_RecordAddedDateTime";
                query += ")";
                query += "values";
                query += "(";
                query += "'" + dtoEventRegister.EventRegister_EventID + "',";
                query += "'" + dtoEventRegister.EventRegister_PlayerID + "',";
                query += "'" + dtoEventRegister.EventRegister_PlayerUsername + "',";
                query += "'" + dtoEventRegister.EventRegister_Status + "',";
                query += "'" + dtoEventRegister.EventRegister_RecordAddedDateTime+ "'";
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
            if (dtoEventRegister.EventRegister_ID > 0)
            {
                query += " where EventRegister_ID=" + dtoEventRegister.EventRegister_ID;
            }

            #endregion
            bStatus = SqlAPI.Save(query) > 0 ? true : false;
            return bStatus;
        }
        #endregion 

        #region GetAll
        public static Collection<EventRegisterDTO> EventRegisterCollection
        {
            get
            {
                query = "select * from " + TableName;

                Collection<EventRegisterDTO> collEventRegister = new Collection<EventRegisterDTO>();

                Collection<DataRow> collDataRow = SqlAPI.GetAll(query);

                if (collDataRow.Count > 0)
                {
                    foreach (DataRow itemRow in collDataRow)
                    {
                        collEventRegister.Add(new EventRegisterDTO()
                        {
                            EventRegister_ID = itemRow.Field<int?>("EventRegister_ID"),
                            EventRegister_EventID = itemRow.Field<int?>("EventRegister_EventID"),
                            EventRegister_PlayerUsername = itemRow.Field<string>("EventRegister_PlayerUsername"),
                            EventRegister_PlayerID = itemRow.Field<int?>("EventRegister_PlayerID"),
                            EventRegister_Status = itemRow.Field<int?>("EventRegister_Status"),
                            //EventRegister_RecordAddedDateTime = itemRow.Field<Int64?>("EventRegister_RecordAddedDateTime")
                        });
                    }
                }
                return collEventRegister;
            }
        }
        #endregion
    }
}
