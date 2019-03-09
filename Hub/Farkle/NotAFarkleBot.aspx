<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="NotAFarkleBot.aspx.cs" Inherits="Hub.Farkle.NotAFarkleBot" %>

<html>
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <meta name="description" content="A gaming platform for web API developers." />
    <meta name="author" content="David W. Knight" />
    <title>Not A FarkleBot</title>
    <link <%=cssHref%> rel="stylesheet" />
</head>
<body>
    <div class="floaty" onclick="window.location.href='/Farkle/Home.aspx'">
        <p class="button_line_one">Not A Farkle Bot</p>
        <hr />
        <p class="button_line_two">Please Try Again</p>
    </div>
</body>
</html>
