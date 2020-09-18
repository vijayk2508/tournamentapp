using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TMS.DTO;
using VISE.Core;

namespace TMS.DataManager
{
    public class MatchDataManager : SqlAPI
    {
        #region Global Variable
        private static readonly string TableName = "TMS_Match";
        private MatchDTO dtoMatch;
        #endregion

        #region Constructor
        public MatchDataManager(MatchDTO currentMatch)
        {
            dtoMatch = currentMatch;
        }

        public MatchDataManager()
        {
        }
        #endregion

        #region Save
        public bool Save()
        {
            #region Update
            if (dtoMatch.Match_ID > 0)
            {
                query = "Update ";
                query += TableName;
                query += "set ";
                query += "Match_Image=" + dtoMatch.Match_Image + ",";
                query += "Match_Title=" + dtoMatch.Match_Title + ",";
                query += "Match_Description=" + dtoMatch.Match_Description + " ";
                query += "where Match_ID=" + dtoMatch.Match_ID;
            }
            #endregion

            #region Insert
            else
            {
                query = "insert into ";
                query += TableName;
                query += "(";
                query += "Match_Title,";
                query += "Match_Description,";
                query += "Match_Image,";
                query += "Match_RecordAddedDateTime";
                query += ")";
                query += "values";
                query += "(";
                query += "'" + dtoMatch.Match_Title + "',";
                query += "'" + dtoMatch.Match_Description + "',";
                query += "'" + dtoMatch.Match_Image + "',";
                query += "'" + dtoMatch.Match_RecordAddedDateTime + "'";
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
            if (dtoMatch.Match_ID > 0)
            {
                query += " where Match_ID=" + dtoMatch.Match_ID;
            }

            #endregion
            bStatus = SqlAPI.Save(query) > 0 ? true : false;
            return bStatus;
        }
        #endregion 

        #region GetAll
        public static Collection<MatchDTO> MatchCollection
        {
            get
            {
                query = "select * from " + TableName;

                Collection<MatchDTO> collMatch = new Collection<MatchDTO>();

                Collection<DataRow> collDataRow = SqlAPI.GetAll(query);

                if (collDataRow.Count > 0)
                {
                    foreach (DataRow itemRow in collDataRow)
                    {
                        collMatch.Add(new MatchDTO()
                        {
                            Match_ID = itemRow.Field<int?>("Match_ID"),
                            Match_Title = itemRow.Field<string>("Match_Title"),
                            Match_Description = itemRow.Field<string>("Match_Description"),
                            Match_EventID = itemRow.Field<int?>("Match_EventID"),
                            Match_Image = itemRow.Field<string>("Match_Image"),
                            Match_RecordAddedDateTime = itemRow.Field<long?>("Match_RecordAddedDateTime"),
                        });
                    }
                }
                return collMatch;
            }
        }
        #endregion

        #region GetAll By EventID
        public Collection<MatchDTO> MatchByEventIDCollection
        {
            get
            {
                Collection<MatchDTO> collMatchByEventID = new Collection<MatchDTO>();
                if (MatchCollection!=null)
                {
                    if (MatchCollection.Count > 0)
                    {
                        var dataMatch = MatchCollection.Where(x => x.Match_EventID == dtoMatch.Match_EventID).ToList();
                        collMatchByEventID = new Collection<MatchDTO>(dataMatch);
                    }
                }

                return collMatchByEventID;
            }
        }
        #endregion
    }
}
