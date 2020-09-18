using System;

namespace TMS.DTO
{
    public class MatchDTO
    {
        private Int32? mMatch_ID = -1;
        private string mMatch_Title = string.Empty;
        private string mMatch_Description = string.Empty;
        private string mMatch_Image = string.Empty;
        private Int32? mMatch_EventID = -1;
        private Int64? mMatch_DateTime = 0;
        private Int64? mMatch_StartRegistrationDateTime = 0;
        private Int64? mMatch_EndRegistrationDateTime = 0;
        private Int64? mMatch_RecordAddedDateTime = 0;
        private Int32? mMatch_RecordAddedBy = 0;
        private Int64? mMatch_RecordUpdatedDateTime = 0;
        private Int64? mMatch_RecordUpdatedBy = 0;
        private Int32? mMatch_RecordStatus = 0;

        public int? Match_ID { get => mMatch_ID; set => mMatch_ID = value; }
        public string Match_Title { get => mMatch_Title; set => mMatch_Title = value; }
        public string Match_Description { get => mMatch_Description; set => mMatch_Description = value; }
        public string Match_Image { get => mMatch_Image; set => mMatch_Image = value; }
        public int? Match_EventID { get => mMatch_EventID; set => mMatch_EventID = value; }
        public long? Match_DateTime { get => mMatch_DateTime; set => mMatch_DateTime = value; }
        public long? Match_StartRegistrationDateTime { get => mMatch_StartRegistrationDateTime; set => mMatch_StartRegistrationDateTime = value; }
        public long? Match_EndRegistrationDateTime { get => mMatch_EndRegistrationDateTime; set => mMatch_EndRegistrationDateTime = value; }
        public long? Match_RecordAddedDateTime { get => mMatch_RecordAddedDateTime; set => mMatch_RecordAddedDateTime = value; }
        public int? Match_RecordAddedBy { get => mMatch_RecordAddedBy; set => mMatch_RecordAddedBy = value; }
        public long? Match_RecordUpdatedDateTime { get => mMatch_RecordUpdatedDateTime; set => mMatch_RecordUpdatedDateTime = value; }
        public long? Match_RecordUpdatedBy { get => mMatch_RecordUpdatedBy; set => mMatch_RecordUpdatedBy = value; }
        public int? Match_RecordStatus { get => mMatch_RecordStatus; set => mMatch_RecordStatus = value; }
    }
}
