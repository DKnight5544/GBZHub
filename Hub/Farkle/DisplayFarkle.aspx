<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="DisplayFarkle.aspx.cs" Inherits="Hub.Farkle.DisplayFarkle" %>

<html>

<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <meta name="description" content="A gaming platform for web API developers." />
    <meta name="author" content="David W. Knight" />
    <title>Play Farkle</title>
    <link <%=cssHref1%> rel="stylesheet" />
    <link <%=cssHref2%> rel="stylesheet" />
</head>
<body>

    <iframe class="floaty" id ="iframeObject" runat="server" scrolling="no" style="opacity:1;">
    </iframe>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <div id="fizban_turn_template" runat="server">
        <div class="floaty color_scheme_two">
            <table class="moves_table">
                <tr>
                    <td class="td1 turn_header_col color_scheme_{0}" colspan="1">{1}</td>
                    <td class="td1 dice_throw_col" colspan="3">{2}</td>
                </tr>
                <tr>
                    <td class="td1">Bot Response:</td>
                    <td class="td1">{3}</td>
                    <td class="td1">HUB:</td>
                    <td class="td1">{4}</td>
                </tr>
                <tr>
                    <td class="td1">New Points:</td>
                    <td class="td1">{5}</td>
                    <td class="td1">Risking:</td>
                    <td class="td1">{6}</td>
                </tr>
                <tr>
                    <td class="td1">Action:</td>
                    <td class="td1">{7}</td>
                    <td class="td1">Banked:</td>
                    <td class="td1">{8}</td>
                </tr>
            </table>
        </div>
    </div>

    <asp:Literal ID="fizban_turn" runat="server"></asp:Literal>

</body>


</html>