using System;

namespace TMS.DTO
{
    public class PlayerDTO
    {
        private Int32? mPlayer_ID = -1;
        private string mPlayer_Name = string.Empty;
        private Int64? mPlayer_DOB = 0;
        private Int32? mPlayer_Gender = 0;
        private string mPlayer_Email = string.Empty;
        private Int32? mPlayer_isEmailVerified = 0;
        private string mPlayer_MobileNo = string.Empty;
        private Int32? mPlayer_isMobileVerified = 0;
        private string mPlayer_WhatsAppNo = string.Empty;
        private string mPlayer_Password = string.Empty;
        private string mPlayer_PaytmNo = string.Empty;
        private string mPlayer_Note = string.Empty;
        private Int32? mPlayer_Status = 0;
        private Int64? mPlayer_RecordAddedDateTime = 0;
        private Int64? mPlayer_RecordUpdatedDateTime = 0;
        private Int32? mPlayer_RecordStatus = 0;

        public int? Player_ID { get => mPlayer_ID; set => mPlayer_ID = value; }
        public string Player_Name { get => mPlayer_Name; set => mPlayer_Name = value; }
        public long? Player_DOB { get => mPlayer_DOB; set => mPlayer_DOB = value; }
        public int? Player_Gender { get => mPlayer_Gender; set => mPlayer_Gender = value; }
        public string Player_Email { get => mPlayer_Email; set => mPlayer_Email = value; }
        public int? Player_isEmailVerified { get => mPlayer_isEmailVerified; set => mPlayer_isEmailVerified = value; }
        public string Player_MobileNo { get => mPlayer_MobileNo; set => mPlayer_MobileNo = value; }
        public int? Player_isMobileVerified { get => mPlayer_isMobileVerified; set => mPlayer_isMobileVerified = value; }
        public string Player_WhatsAppNo { get => mPlayer_WhatsAppNo; set => mPlayer_WhatsAppNo = value; }
        public string Player_Password { get => mPlayer_Password; set => mPlayer_Password = value; }
        public string Player_PaytmNo { get => mPlayer_PaytmNo; set => mPlayer_PaytmNo = value; }
        public string Player_Note { get => mPlayer_Note; set => mPlayer_Note = value; }
        public int? Player_Status { get => mPlayer_Status; set => mPlayer_Status = value; }
        public long? Player_RecordAddedDateTime { get => mPlayer_RecordAddedDateTime; set => mPlayer_RecordAddedDateTime = value; }
        public long? Player_RecordUpdatedDateTime { get => mPlayer_RecordUpdatedDateTime; set => mPlayer_RecordUpdatedDateTime = value; }
        public int? Player_RecordStatus { get => mPlayer_RecordStatus; set => mPlayer_RecordStatus = value; }
    }
}
