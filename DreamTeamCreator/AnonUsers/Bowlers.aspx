<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bowlers.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Bowlers"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br></br>
<br></br>
<table style="width: 100%;">
<tr>
    <td>
        <asp:DropDownList ID="DropTeam" runat="server" OnSelectedIndexChanged="DropTeamSelect" DataTextField = "teams" DataValueField = "id"></asp:DropDownList>
    </td>
    <td>
        <asp:TextBox ID="Name" runat="server" placeholder="Bowler Name"></asp:TextBox>
    </td>
</tr>
</table>
</asp:Content>