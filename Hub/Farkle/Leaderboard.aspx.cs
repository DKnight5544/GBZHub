using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hub.Farkle
{
    public partial class Leaderboard : System.Web.UI.Page
    {

        private static string now = DateTime.Now.Ticks.ToString();
        //public string jsSrc = string.Format("src= 'js/Site.js?{0}'", now);
        public string cssHref1 = string.Format("href='/css/Default.css?{0}'", now);
        public string cssHref2 = string.Format("href='/Farkle/css/Leaderboard.css?{0}'", now);

        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = Environment.GetEnvironmentVariable("APIvAPI_ConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connstr))
            {
                var leaderboard = db.GetLeaderboard();

                foreach(var game in leaderboard)
                {

                    var frame = LoadControl("UserControls/FrameControl.ascx") as UserControls.FrameControl;
                    PlaceHolder1.Controls.Add(frame);
                    frame.url = game.URL;

                    var stats = LoadControl("UserControls/StatsControl.ascx") as UserControls.StatsControl;
                    PlaceHolder1.Controls.Add(stats);
                    stats.BotName = game.BotName;
                    stats.Placement = game.Placement.Value;
                    stats.MoveCount = game.MoveCount.Value;
                    stats.GameTime = String.Format("{0} {1}", game.GameTime.ToShortDateString(), game.GameTime.ToShortTimeString());
                    stats.URL = game.URL;
                    stats.GameId = game.GameId;
                    stats.ButtonOneText = "View Game";
                    stats.ButtonOneDestination = string.Format("DisplayFarkle.aspx?gameid={0}", game.GameId);
                    stats.DisplayAttribute = "none";

                }

            }
        }
    }
}