
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hub.Farkle.CustomClasses;
using Newtonsoft.Json;

namespace Hub
{
    public partial class PlayFarkle : System.Web.UI.Page
    {

        WebClient _webClient = new WebClient();
        char[] _validResponseDiceValues = "123456H".ToArray();


        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["url"];

            if (string.IsNullOrWhiteSpace(url))
            {
                Response.Redirect("default.aspx");
            }

            // Make sure the url is complete
            if (url.Left(7).ToLower() != "http://") url = "http://" + url;

            // See if this is a bot...
            _webClient.QueryString.Clear();
            _webClient.QueryString.Add("cmd", "is_farklebot");
            string isFarkleBot = _webClient.DownloadString(url);

            if (isFarkleBot.ToUpper() != "YES")
            {
                Response.Redirect("/Farkle/NotAFarkleBot.aspx");
            }

            // Get Payment Info
            _webClient.QueryString.Clear();
            _webClient.QueryString.Add("cmd", "payment_info");
            string paymentInfo = _webClient.DownloadString(url);

            // Get Bot Name
            _webClient.QueryString.Clear();
            _webClient.QueryString.Add("cmd", "bot_name");
            string botName = _webClient.DownloadString(url);

            string connstr = Environment.GetEnvironmentVariable("APIvAPI_ConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connstr))
            {
                int nameLength = botName.Length <= 20 ? botName.Length : 20;
                db.AddUpdateBot(url, paymentInfo,botName.Substring(0,nameLength));

                int gameId = Play(url, db);

                string display = string.Format("DisplayFarkle.aspx?gameid={0}", gameId);

                Response.Redirect(display);

            }

        }

        private int Play(string url, DWKDBDataContext db)
        {

            int pointsBanked = 0;
            int pointsAtRisk = 0;
            bool isBank = false;
            bool isFarkle = false;
            bool isIllegal = false;
            int diceCount = 6;
            string response = "";
            ValidateResponseResult validatedResult;
            int newPoints;
            int turnNumber = 0;
            int gameId = 0;
            var randomizer = new CustomClasses.DiceTosser();

            var result = db.AddGame(url).SingleOrDefault();
            gameId = result.GameId;

            var moveList = new List<Move>();

            while (pointsBanked < 10000 && turnNumber <= 200)
            {
                pointsAtRisk = 0;
                isBank = false;
                isFarkle = false;
                isIllegal = false;
                diceCount = 6;
                response = "";
                newPoints = 0;
                validatedResult.IsValid = false;
                validatedResult.Dice = "";
                validatedResult.Move = "";

                while (!isBank && !isIllegal)
                {

                    string dice = randomizer.GetRandomDice(diceCount);
                    string originalDice = dice;

                    turnNumber++;


                    isFarkle = IsFarkle(dice);

                    _webClient.QueryString.Clear();
                    _webClient.QueryString.Add("banked", pointsBanked.ToString());
                    _webClient.QueryString.Add("at_risk", pointsAtRisk.ToString());
                    _webClient.QueryString.Add("turn_count", turnNumber.ToString());
                    _webClient.QueryString.Add("cmd", "move");

                    if (isFarkle)
                    {
                        _webClient.QueryString.Add("dice", "farkle");
                        response = _webClient.DownloadString(url);
                        newPoints = 0;
                        pointsAtRisk = 0;
                        diceCount = 6;
                    }

                    else
                    {
                        _webClient.QueryString.Add("dice", dice);
                        response = _webClient.DownloadString(url);

                        validatedResult = ValidateResponse(response, diceCount);

                        if (validatedResult.IsValid)
                        {
                            string heldDice = "";
                            for (int idx = 0; idx < diceCount; idx++)
                            {
                                if (validatedResult.Dice.Substring(idx, 1) == "H") heldDice += dice.Substring(idx, 1);
                            }

                            newPoints = GetPoints(heldDice);

                            if (newPoints > 0)
                            {
                                pointsAtRisk += newPoints;

                                if (validatedResult.Move.ToUpper() == "BANK")
                                {
                                    pointsBanked += pointsAtRisk;
                                    isBank = true;
                                }
                                else
                                {
                                    diceCount -= heldDice.Count();
                                    if (diceCount == 0) diceCount = 6;
                                }

                            }
                            else //Illegal - Bad Pull
                            {
                                isIllegal = true;
                                pointsAtRisk = 0;
                            }
                        }
                        else // illegal - Bad Response
                        {
                            isIllegal = true;
                            pointsAtRisk = 0;
                        }

                    } // Not Farkle

                    //record move
                    var move = new Move();
                    move.Turn = turnNumber;
                    move.Dice = originalDice;
                    move.Response = response;
                    move.NewPoints = newPoints;
                    move.PointsInPlay = pointsAtRisk;
                    move.BankedPoints = pointsBanked;
                    move.IsFarkle = isFarkle;
                    move.IsIllegal = isIllegal;
                    moveList.Add(move);

                }

            } //loop till 10000 points

            //Save the moves
            string movesJson = JsonConvert.SerializeObject(moveList);
            int moveCount = moveList.Count();
            db.EndGame(gameId, moveCount, movesJson);


            return gameId;
        }

        private bool IsFarkle(string dice)
        {
            if (GetPoints(dice) > 0) return false;

            if (dice.Contains("1")) return false;
            if (dice.Contains("5")) return false;

            dice = String.Concat(dice.OrderByDescending(c => c));

            if (dice.Contains("222")) return false;
            if (dice.Contains("333")) return false;
            if (dice.Contains("444")) return false;
            if (dice.Contains("666")) return false;

            return true;
        }

        private int GetPoints(string dice)
        {
            return PointsManager.FetchPoints(dice);
        }

        private ValidateResponseResult ValidateResponse(string response, int originalDiceCount)
        {
            ValidateResponseResult result = new ValidateResponseResult();
            result.IsValid = false;

            //Response cannot be NULL
            if (string.IsNullOrWhiteSpace(response)) return result;

            //Must split into two parts on comma...
            var responseArray = response.Split(':');

            if (responseArray.Count() != 2) return result;

            result.Dice = responseArray[0];
            result.Move = responseArray[1].Substring(0, 4);

            //Dice must be the same length as original.
            if (result.Dice.Count() != originalDiceCount) return result;

            //Dice values 1-6, and 'H' are valid.
            var testDice = result.Dice.ToArray();
            int invalidCount = testDice.Except(_validResponseDiceValues).Count();
            if (invalidCount > 0) return result;

            //Move must be bank or roll
            if (!"BANK:ROLL".Contains(result.Move.ToUpper())) return result;

            result.IsValid = true;
            return result;
        }

        private struct ValidateResponseResult
        {
            public bool IsValid;
            public string Dice;
            public string Move;
        }

    }


}