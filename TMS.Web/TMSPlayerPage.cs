using System.Collections.ObjectModel;
using System.Linq;
using TMS.DataManager;
using TMS.DTO;
using VISE.Core.Library.Helper;

namespace TMS.Web
{
    public class TMSPlayerPage : System.Web.UI.Page
    {
        public static PlayerDTO CurrentPlayer { get; set; } = new PlayerDTO();

        public TMSPlayerPage(PlayerDTO dtoPlayer)
        {
            CurrentPlayer = dtoPlayer;
        }

        public TMSPlayerPage()
        {

        }
    }
}
