using VISE.Core.Library.Helper;

namespace TMS.Library
{
    public enum ePlayerEventRegisterationStatus
    {
        [EnumDescription("Select")]
        None = 0,
        
        [EnumDescription("Approved")]
        Approved,

        [EnumDescription("Rejected")]
        Rejected,

        [EnumDescription("Open")]
        Open,

        [EnumDescription("Close")]
        Close,
    }
    
    public enum eParticipantType
    {
        [EnumDescription("Select")]
        None = 0,

        [EnumDescription("Solo")]
        Solo,

        [EnumDescription("Duo")]
        Duo,

        [EnumDescription("Squard")]
        Squard,
    }
}
