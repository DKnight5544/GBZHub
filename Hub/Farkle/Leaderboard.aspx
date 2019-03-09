<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="Hub.Farkle.Leaderboard" %>

<html>
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <meta name="description" content="A gaming platform for web API developers." />
    <meta name="author" content="David W. Knight" />
    <title>Leaderboard</title>
    <link <%=cssHref1%> rel="stylesheet" />
    <link <%=cssHref2%> rel="stylesheet" />

    <script type="text/javascript">

        let floaties;

        function body_onload() {
            floaties = document.getElementsByClassName("floaty");
        }

        function toggleView() {
            for (let i = 0; i < floaties.length; i++) {
                let floaty = floaties[i];
                floaty.style.display = floaty.style.display == "none" ? "block" : "none";
            }
        }


    </script>

</head>
<body onload="body_onload();" onclick="toggleView();">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</body>

</html>

