
using System;
using System.Collections.Generic;
using System.Linq;
using Hub.Farkle.CustomClasses;
using Newtonsoft.Json;

namespace Hub.Farkle
{
    public partial class DisplayFarkle : System.Web.UI.Page
    {

        private static string now = DateTime.Now.Ticks.ToString();
        //public string jsSrc = string.Format("src= 'js/Site.js?{0}'", now);
        public string cssHref1 = string.Format("href='/css/default.css?{0}'", now);
        public string cssHref2 = string.Format("href='/Farkle/css/DisplayFarkle.css?{0}'", now);


        protected void Page_Load(object sender, EventArgs e)
        {
            string gameId = Request.QueryString["gameid"];

            if (string.IsNullOrWhiteSpace(gameId))
            {
                Response.Redirect("/Farkle/Home.aspx");
            }
            
            string connstr = Environment.GetEnvironmentVariable("APIvAPI_ConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connstr))
            {
                int iGameId = int.Parse(gameId);
                var game = db.GetGame(iGameId).Single();

                var moves = JsonConvert.DeserializeObject<List<Move>>(game.Moves);

                this.iframeObject.Attributes.Add("src", game.URL);

                var stats = LoadControl("UserControls/StatsControl.ascx") as UserControls.StatsControl;
                PlaceHolder1.Controls.Add(stats);
                stats.BotName = game.BotName;
                stats.Placement = game.Placement.Value;
                stats.MoveCount = game.MoveCount.Value;
                stats.GameTime = String.Format("{0} {1}", game.GameTime.ToShortDateString(), game.GameTime.ToShortTimeString());
                stats.URL = game.URL;
                stats.GameId = game.GameId;
                stats.ButtonOneText = "View Leaderboard";
                stats.ButtonOneDestination = "Leaderboard.aspx";
                stats.DisplayAttribute = "block";

                Display(moves);

            }

        }

        private void Display(List<Move> moves)
        {

            string move_template = fizban_turn_template.InnerHtml;
            fizban_turn_template.InnerHtml = "";
            int idx = 0;

            const string diceHtmlBase = @"
<div class='dice_container {0}'>
    <img src = '/farkle/images/dice.jpg' class='dice_{1}'/>
</div>
";

            foreach (Move move in moves)
            {
                idx = 0;
                string diceHtml = "";
                foreach (char die in move.Dice.ToCharArray())
                {
                    diceHtml += string.Format(diceHtmlBase
                        , !move.IsFarkle && move.Response.Substring(idx, 1) == "H" ? "hold" : "roll"
                        , move.Dice.Substring(idx, 1)
                        );
                    idx++;
                }

                if (move.IsFarkle)
                {
                    fizban_turn.Text += string.Format(move_template
                        , "four"
                        , move.Turn
                        , diceHtml
                        , move.Response
                        , "FARKLE"
                        , 0
                        , move.PointsInPlay
                        , "FARKLE"
                        , move.BankedPoints
                        );

                }
                else
                {
                    string[] response = move.Response.Split(':');

                    fizban_turn.Text += string.Format(move_template
                        , move.IsIllegal ? "four" : "three"
                        , move.Turn
                        , diceHtml
                        , response[0]
                        , move.IsIllegal ? "Bad Pull" : "OK"
                        , move.NewPoints
                        , move.PointsInPlay
                        , response[1]
                        , move.BankedPoints
                        );

                }

            }

        }

        
    }


}