using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TMS.DTO;
using VISE.Core;
using VISE.Core.Library.Helper;

namespace TMS.DataManager
{
    public class PlayerDataManager : SqlAPI
    {
        #region Global Variable
        private static readonly string TableName = "TMS_Player";
        private PlayerDTO dtoPlayer;
        #endregion

        #region Constructor
        public PlayerDataManager(PlayerDTO currentPlayer)
        {
            dtoPlayer = currentPlayer;
        }

        public PlayerDataManager()
        {
        }
        #endregion

        #region Save
        public bool Save()
        {
            #region Update
            if (dtoPlayer.Player_ID > 0)
            {
                query = "Update ";
                query += TableName;
                query += "set ";
                query += "Player_Name=" + dtoPlayer.Player_Name + ",";
                query += "Player_DOB=" + dtoPlayer.Player_DOB + ",";
                query += "Player_Gender=" + dtoPlayer.Player_Gender + ",";
                query += "Player_EmailVerifyStatus=" + dtoPlayer.Player_isEmailVerified + ",";
                query += "Player_Email=" + Authentication.Encrypt(dtoPlayer.Player_Email) + ",";
                query += "Player_MobileNoVerifyStatus=" + dtoPlayer.Player_isMobileVerified + ",";
                query += "Player_MobileNo=" + dtoPlayer.Player_MobileNo + ",";
                query += "Player_WhatsAppNo=" + dtoPlayer.Player_WhatsAppNo + ",";
                query += "Player_PaytmNo=" + dtoPlayer.Player_PaytmNo + ",";
                query += "Player_Password=" + Authentication.Encrypt(dtoPlayer.Player_Password) + ",";
                query += "Player_Status=" + dtoPlayer.Player_Status + ",";
                query += "Player_Note=" + dtoPlayer.Player_Note + " ";
                query += "where Player_ID=" + dtoPlayer.Player_ID;
            }
            #endregion

            #region Insert
            else
            {
                query = "insert into ";
                query += TableName;
                query += "(";
                query += "Player_Name,";
                query += "Player_Email,";
                query += "Player_MobileNo,";
                query += "Player_Password";
                query += ")";
                query += "values";
                query += "(";
                query += "'" + dtoPlayer.Player_Name + "',";
                query += "'" + Authentication.Encrypt(dtoPlayer.Player_Email) + "',";
                query += "'" + dtoPlayer.Player_MobileNo + "',";
                query += "'" + Authentication.Encrypt(dtoPlayer.Player_Password) + "'";
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
            if (dtoPlayer.Player_ID > 0)
            {
                query += " where Player_ID=" + dtoPlayer.Player_ID;
            }

            #endregion
            bStatus = SqlAPI.Save(query) > 0 ? true : false;
            return bStatus;
        }
        #endregion 

        #region GetAll
        public Collection<PlayerDTO> PlayerCollection
        {
            get
            {
                query = "select * from " + TableName;

                Collection<PlayerDTO> collPlayer = new Collection<PlayerDTO>();

                Collection<DataRow> collDataRow = SqlAPI.GetAll(query);

                if (collDataRow.Count > 0)
                {
                    foreach (DataRow itemRow in collDataRow)
                    {
                        collPlayer.Add(new PlayerDTO()
                        {
                            Player_ID = itemRow.Field<int?>("Player_ID"),
                            Player_Name = itemRow.Field<string>("Player_Name"),
                            Player_DOB = itemRow.Field<long?>("Player_DOB"),
                            Player_Gender = itemRow.Field<int?>("Player_Gender"),
                            Player_isEmailVerified = itemRow.Field<int?>("Player_isEmailVerified"),
                            Player_Email = Authentication.Decrypt(itemRow.Field<string>("Player_Email")),
                            Player_isMobileVerified = itemRow.Field<int?>("Player_isMobileVerified"),
                            Player_MobileNo = itemRow.Field<string>("Player_MobileNo"),
                            Player_WhatsAppNo = itemRow.Field<string>("Player_WhatsAppNo"),
                            Player_PaytmNo = itemRow.Field<string>("Player_PaytmNo"),
                            Player_Password = Authentication.Decrypt(itemRow.Field<string>("Player_Password")),
                            Player_RecordAddedDateTime = itemRow.Field<long?>("Player_RecordAddedDateTime"),
                            Player_RecordUpdatedDateTime = itemRow.Field<long?>("Player_RecordUpdatedDateTime"),
                            Player_RecordStatus = itemRow.Field<int?>("Player_RecordStatus"),
                            Player_Status = itemRow.Field<int?>("Player_Status"),
                            Player_Note = itemRow.Field<string>("Player_Note")
                        });
                    }
                }
                return collPlayer;
            }
        }
        #endregion

        #region Auth
        public bool Auth()
        {
            bStatus = false;
            if (PlayerCollection.Count > 0)
            {
                PlayerDTO CurrentPlayer = PlayerCollection.Where(x => (x.Player_Email == dtoPlayer.Player_Email) && (x.Player_Password == dtoPlayer.Player_Password)).FirstOrDefault();
                //PlayerDTO nCurrentPlayer = PlayerCollection.SingleOrDefault(x => (x.Player_Email == dtoPlayer.Player_Email) && (x.Player_Password == dtoPlayer.Player_Password));
                if (CurrentPlayer != null)
                {
                    if (CurrentPlayer.Player_ID > 0)
                    {
                        bStatus = true;
                    }
                }
            }
            return bStatus;
        }
        #endregion

        #region Auth
        public PlayerDTO isEmailOrMobileExist
        {
            get
            {
                PlayerDTO CurrentPlayer = new PlayerDTO();
                if (PlayerCollection.Count > 0)
                {
                    CurrentPlayer = PlayerCollection.Where(x => x.Player_Email == dtoPlayer.Player_Email || x.Player_MobileNo == dtoPlayer.Player_MobileNo).FirstOrDefault();
                }
                return CurrentPlayer;
            }
        }
        #endregion
    }
}
