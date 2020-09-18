using System;

namespace TMS.DTO
{
    public class EventRegisterDTO
    {
        private int? mEventRegister_ID = -1;
        private string mEventRegister_PlayerUsername = string.Empty;
        private int? mEventRegister_EventID = -1;
        private int? mEventRegister_PlayerID = -1;
        private int? mEventRegister_Status = 0;
        private Int64? mEventRegister_RecordAddedDateTime = 0;

        public int? EventRegister_ID { get => mEventRegister_ID; set => mEventRegister_ID = value; }
        public string EventRegister_PlayerUsername { get => mEventRegister_PlayerUsername; set => mEventRegister_PlayerUsername = value; }
        public int? EventRegister_EventID { get => mEventRegister_EventID; set => mEventRegister_EventID = value; }
        public int? EventRegister_PlayerID { get => mEventRegister_PlayerID; set => mEventRegister_PlayerID = value; }
        public Int64? EventRegister_RecordAddedDateTime
        {
            get => DateTime.Now.Ticks;
            set => mEventRegister_RecordAddedDateTime = (Int64?)value;
         }
        public int? EventRegister_Status { get => mEventRegister_Status; set => mEventRegister_Status = value; }
    }
}
