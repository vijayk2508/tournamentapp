using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using TMS.DataManager;
using TMS.DTO;

namespace TMS.Web
{
    public class TMSPlayerMaster : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (HttpContext.Current.Session["Player_Email"] == null)
            {
                Response.Redirect("~/Login/");
            }
            else
            {
                string sEmail = HttpContext.Current.Session["Player_Email"].ToString();

                Collection<PlayerDTO> collPlayers = new PlayerDataManager().PlayerCollection;

                if (collPlayers.Count > 0 && collPlayers != null)
                {
                    PlayerDTO dtoPlayer = collPlayers.Where(x => x.Player_Email == sEmail).FirstOrDefault();
                    TMSPlayerPage currentPage = new TMSPlayerPage(dtoPlayer);
                }
            }
        }
    }
}
