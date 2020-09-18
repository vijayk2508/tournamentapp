using VISE.Core.Library.Helper;

namespace TMS.Library
{
    public enum ePubgMatchType
    {
        [EnumDescription("Select")]
        None = 0,

        [EnumDescription("Classic")]
        Classic,

        [EnumDescription("Arcade")]
        Arcade,

        [EnumDescription("Event Zombie Mode")]
        EventZombieMode,
    }

    public enum ePubgMatchMapType
    {
        [EnumDescription("Select")]
        None = 0,

        [EnumDescription("Erangle")]
        Erangle,

        [EnumDescription("Miramar")]
        Miramar,

        [EnumDescription("Shanok")]
        Shanok,

        [EnumDescription("Vikend")]
        Vikend,
    }


    public enum ePubgMatchVersionType
    {
        [EnumDescription("Select")]
        None = 0,

        [EnumDescription("TPP")]
        TPP,

        [EnumDescription("FPP")]
        FPP,
    }
}