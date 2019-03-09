using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hub.Farkle.UserControls
{
    public partial class StatsControl : System.Web.UI.UserControl
    {
        public string BotName { get; set; }
        public int Placement { get; set; }
        public int MoveCount { get; set; }
        public string GameTime { get; set; }
        public int GameId { get; set; }
        public string URL { get; set; }
        public string ButtonOneText { get; set; }
        public string ButtonOneDestination { get; set; }
        public string DisplayAttribute { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
