<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatsControl.ascx.cs" Inherits="Hub.Farkle.UserControls.StatsControl" %>

<div class="floaty" style="background-color: aqua; display: <%=DisplayAttribute%>;">
    <table class="stats_table">
        <tr>
            <td class="stats_table_cell_left">
                <p class="stats_table_para">Placement</p>
            </td>
            <td class="stats_table_cell_right">
                <p class="stats_table_para"><%=BotName%> - <%=Placement %></p>
            </td>
        </tr>
        <tr>
            <td class="stats_table_cell_left">
                <p class="stats_table_para">Move Count</p>
            </td>
            <td class="stats_table_cell_right">
                <p class="stats_table_para"><%=MoveCount %></p>
            </td>
        </tr>
        <tr>
            <td class="stats_table_cell_left">
                <p class="stats_table_para">Game Number</p>
            </td>
            <td class="stats_table_cell_right">
                <p class="stats_table_para"><%=GameId%></p>
            </td>
        </tr>
        <tr>
            <td class="stats_table_cell_left">
                <p class="stats_table_para">Game (server) Time</p>
            </td>
            <td class="stats_table_cell_right">
                <p class="stats_table_para"><%=GameTime%></p>
            </td>
        </tr>
        <tr>
            <td class="stats_table_cell_left">
                <button onclick="window.location.href='<%=ButtonOneDestination%>'"><%=ButtonOneText%></button>
            </td>
            <td class="stats_table_cell_right">
                <button onclick ="window.location.href='PlayFarkle.aspx?url=<%=URL%>'">Play New Game</button>
            </td>
        </tr>
    </table>
</div>
