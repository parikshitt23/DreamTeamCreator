<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="DreamTeamCreator.AnonUsers.Team" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />    <br />    <br />    <br />

     <asp:DropDownList ID="DropTeam" runat="server">
            <asp:ListItem Text="Select Team.."  Value="0" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Chennai Super Kings"  Value="1"></asp:ListItem>
            <asp:ListItem Text="Deccan Chargers"  Value="2"></asp:ListItem>
            <asp:ListItem Text="Delhi Daredevils"  Value="3"></asp:ListItem>
            <asp:ListItem Text="Kings XI Punjab"  Value="4"></asp:ListItem>
            <asp:ListItem Text="Kochi Tuskers Kerala"  Value="5"></asp:ListItem>
            <asp:ListItem Text="Kolkata Knight Riders"  Value="6"></asp:ListItem>
            <asp:ListItem Text="Mumbai Indians"  Value="7"></asp:ListItem>
            <asp:ListItem Text="Pune Warriors"  Value="8"></asp:ListItem>
            <asp:ListItem Text="Rajasthan Royals"  Value="9"></asp:ListItem>
            <asp:ListItem Text="Royal Challengers Bangalore"  Value="10"></asp:ListItem>
            <asp:ListItem Text="Sunrisers Hyderabad"  Value="11"></asp:ListItem>
        </asp:DropDownList>

    
</asp:Content>
