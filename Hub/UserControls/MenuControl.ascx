<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="Hub.UserControls.MenuControl" %>

<div id="FloatyDiv" class="floaty" runat="server">
    <table class="menu_table">
        <tr>
            <td class="menu_title" colspan="2">
                <asp:Literal ID="MenuTitle" runat="server">No Title</asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="menu_cell">
                <button id="ButtonOne" class="menu_button" runat="server" disabled>
                    <asp:Literal ID="ButtonOneText" runat="server"></asp:Literal>
                </button>
            </td>
            <td class="menu_cell">
                <button id="ButtonTwo" class="menu_button" runat="server" disabled>
                    <asp:Literal ID="ButtonTwoText" runat="server"></asp:Literal>
                </button>
            </td>
        </tr>
        <tr>
            <td class="menu_cell">
                <button id="ButtonThree" class="menu_button" runat="server" disabled>
                    <asp:Literal ID="ButtonThreeText" runat="server"></asp:Literal>
                </button>
            </td>
            <td class="menu_cell">
                <button id="ButtonFour" class="menu_button" runat="server" disabled>
                    <asp:Literal ID="ButtonFourText" runat="server"></asp:Literal>
                </button>
            </td>
        </tr>
        <tr>
            <td class="menu_cell">
                <button id="ButtonFive" class="menu_button" runat="server" disabled>
                    <asp:Literal ID="ButtonFiveText" runat="server"></asp:Literal>
                </button>
            </td>
            <td class="menu_cell">
                <button id="ButtonSix" class="menu_button" runat="server" disabled>
                    <asp:Literal ID="ButtonSixText" runat="server"></asp:Literal>
                </button>
            </td>
        </tr>
    </table>
</div>
