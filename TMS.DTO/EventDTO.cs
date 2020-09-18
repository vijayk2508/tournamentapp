using System;

namespace TMS.DTO
{
    public class EventDTO
    {
        private Int32? mEvent_ID = -1;
        
        private string mEvent_Title = string.Empty;
        private string mEvent_Description = string.Empty;
        private string mEvent_Image = string.Empty;
        private Int64? mEvent_RecordAddedDateTime = 0;
        
        public Int32? Event_ID { get => mEvent_ID; set => mEvent_ID = value; }
        public string Event_Title { get => mEvent_Title; set => mEvent_Title = value; }
        public string Event_Description { get => mEvent_Description; set => mEvent_Description = value; }
        public string Event_Image { get => mEvent_Image; set => mEvent_Image = value; }
        public Int64? Event_RecordAddedDateTime { get => mEvent_RecordAddedDateTime; set => mEvent_RecordAddedDateTime = value; }
    }
}
