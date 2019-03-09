<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Hub.Farkle.Home" %>

<html>
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <meta name="description" content="A gaming platform for web API developers." />
    <meta name="author" content="David W. Knight" />
    <title>Farkle Home</title>
    <link <%=cssHref1%> rel="stylesheet" />
    <link <%=cssHref2%> rel="stylesheet" />
    <script type="text/javascript">

        let url_input

        function body_onload() {
            url_input = document.getElementById("url_input");
            url_input.addEventListener("keyup", function (event) {
                event.preventDefault();
                if (event.keyCode === 13) { PracticeFarkle(); }
            });


        }

        function PracticeFarkle() {
            if (url_input.value == "") {
                url_input.focus();
                return false;
            }
            window.location.href = "/Farkle/PlayFarkle.aspx?url=" + url_input.value;

        }

    </script>
</head>
<body onload="body_onload();">
    <div class="floaty" onclick="window.location.href='/Farkle/FarkleAPI.pdf'">
        <p class="button_line_one">About Farkle</p>
        <hr />
        <p class="button_line_two">The Game and how to build a Farkle Bot</p>
    </div>
    <div class="floaty" onclick="window.location.href='/Farkle/Leaderboard.aspx'">
        <p class="button_line_one">Leaderboard</p>
        <hr />
        <p class="button_line_two">Meet The Top 10 Farkle Bots</p>
    </div>
    <div class="floaty" onclick="PracticeFarkle();">
        <p class="button_line_one">Play Farkle</p>
        <hr />
        <input id="url_input"
            type='url'
            class='url_input'
            placeholder="Paste your Farkle Bot link here . . ." />
    </div>
    <div class="floaty" onclick="window.location.href='/Farkle/PlayFarkle.aspx?url=http://dwkbots.azurewebsites.net/Fizban.aspx'">
        <p class="button_line_one">Demo Fizban</p>
        <hr />
        <p class="button_line_two">Watch Fizban Play an Actual Game</p>
    </div>
</body>

</html>
